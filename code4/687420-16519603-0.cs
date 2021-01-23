    public static void Main()
    {
        // ...
        var signedDoc = new XmlDocument { PreserveWhitespace = true };
        signedDoc.Load("test_signed.xml");
        foreach (XmlElement root in signedDoc.GetElementsByTagName("PackageRoot"))
        {
            foreach (XmlElement signature in root.GetElementsByTagName("Signature"))
            {
                var success = signature.VerifySignature(certificate);
                Console.WriteLine(success ? " successful!" : " failed!");
            }
        }
        Console.WriteLine("Done.");
        Console.ReadLine();
    }
    public static void Sign(this XmlElement element, X509Certificate2 certificate)
    {
        var identifier = Guid.NewGuid().ToString("N");
        element.SetAttribute("Id", identifier);
        var signedXml = new SignedXml(element) { SigningKey = certificate.PrivateKey };
        signedXml.AddReference(new Reference("#" + identifier));
        signedXml.ComputeSignature();
        var xmlDigitalSignature = signedXml.GetXml();
        element.OwnerDocument.DocumentElement.AppendChild(
            element.OwnerDocument.ImportNode(xmlDigitalSignature, true));
    }
    public static bool VerifySignature(this XmlElement element, X509Certificate2 certificate)
    {
        var signedXml = new SignedXml(element.OwnerDocument);
        signedXml.LoadXml(element);
        return signedXml.CheckSignature(certificate, true);
    }
