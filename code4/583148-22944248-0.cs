    var document = new XmlDocument();
    document.LoadXml(txtXml.Text);
    var certificateStr = document.SelectSingleNode("X509Data/X509Certificate").InnerText;
    byte[] data = Convert.FromBase64String(certificateStr);
    var x509 = new X509Certificate2(data);
    Console.WriteLine("Public Key Format: {0}", x509.PublicKey.EncodedKeyValue.Format(true));
