    // Assume the data to sign is in the data.xml file, load it, and
    
    // set up the signature object.
    XmlDocument doc = new XmlDocument();
    
    doc.Load(@"D:\Example.xml");
    SignedXml sig = new SignedXml(doc);
    
    // Make a random RSA key, and set it on the signature for signing.
    RSA key = new RSACryptoServiceProvider();
    
    sig.SigningKey = key;
    
    // Create a Reference to the containing document, add the enveloped
    // transform, and then add the Reference to the signature
    Reference refr = new Reference("");refr.AddTransform(new XmlDsigEnvelopedSignatureTransform());
    
    sig.AddReference(refr);
    
    // Compute the signature, add it to the XML document, and save
    sig.ComputeSignature();
    
    doc.DocumentElement.AppendChild(sig.GetXml());
    doc.Save("data-signed.xml");
    
    // Load the signed data
    
    //XmlDocument doc = new XmlDocument();
    doc.PreserveWhitespace = true;
    
    doc.Load("data-signed.xml");
    
    // Find the Signature element in the document
    XmlNamespaceManager nsm = new XmlNamespaceManager(new NameTable());
    
    nsm.AddNamespace("dsig", SignedXml.XmlDsigNamespaceUrl);
    XmlElement sigElt = (XmlElement)doc.SelectSingleNode("//dsig:Signature", nsm);
    
    // Load the signature for verification
    
    //SignedXml sig = new SignedXml(doc);
    
    sig.LoadXml(sigElt);
    
    // Verify the signature, assume the public key part of the
    
    // signing key is in the key variable
    if (sig.CheckSignature(key))
        Console.WriteLine("Signature verified");
    else
        Console.WriteLine("Signature not valid");
