    //Prompt the user with the list of certificates on the local store.
    //The user have to select the certificate he wants to use for signing.
    //Note: All certificates form the USB device are automatically copied to the local store as soon the device is plugged in.
    X509Store store = new X509Store(StoreLocation.CurrentUser);
    store.Open(OpenFlags.ReadOnly);
    X509CertificateCollection certificates = X509Certificate2UI.SelectFromCollection(store.Certificates,
                                                                                    "Certificados conocidos",
                                                                                    "Por favor seleccione el certificado con el cual desea firmar",
                                                                                    X509SelectionFlag.SingleSelection
                                                                                    );
    store.Close();
    X509Certificate2 certificate = null;
    if (certificates.Count != 0)
    {
        //The selected certificate
        certificate = (X509Certificate2)certificates[0];
    }
    else
    {
        //The user didn't select a certificate
        return "El usuario canceló la selección de un certificado";
    }
    //Check certificate's atributes to identify the type of certificate (censored)
    if (certificate.Issuer != "CN=............................., OU=................., O=..., C=US")
    {
        //The selected certificate is not of the needed type
        return "El certificado seleccionado no corresponde a un token ...";
    }
    //Check if the certificate is issued to the current user
    if (!certificate.Subject.ToUpper().Contains(("E=" + pUserADLogin + "@censoreddomain.com").ToUpper()))
    {
        return "El certificado seleccionado no corresponde al usuario actual";
    }
    //Check if the token is currently plugged in
    XmlDocument xmlDoc = new XmlDocument();
    XmlElement element = xmlDoc.CreateElement("Content", SignedXml.XmlDsigNamespaceUrl.ToString());
    element.InnerText = "comodin";
    xmlDoc.AppendChild(element);
    SignedXml signedXml = new SignedXml();
    try
    {
        signedXml.SigningKey = certificate.PrivateKey;
    }
    catch
    {
        //USB Token is not plugged in
        return "El token no se encuentra conectado al equipo";
    }
    DataObject dataObject = new DataObject();
    dataObject.Data = xmlDoc.ChildNodes;
    dataObject.Id = "CONTENT";
    signedXml.AddObject(dataObject);
    Reference reference = new Reference();
    reference.Uri = "#CONTENT";
    signedXml.AddReference(reference);
    //Attempt to sign the data. The user will be prompted to enter his PIN
    try
    {
        signedXml.ComputeSignature();
    }
    catch
    {
        //User didn't enter the correct PIN
        return "Hubo un error confirmando la identidad del usuario";
    }
    //The user has signed with the correct token
    return String.Format("El usuario {0} ha firmado exitosamente usando el token con serial {1}", pUserADLogin, certificate.SerialNumber);
