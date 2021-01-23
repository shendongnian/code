    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    
    ...
    
    X509Extension extension; // The OID 2.5.29.35 extension
    AsnEncodedData asndata = new AsnEncodedData(extension.Oid, extension.RawData);
    Console.WriteLine(asndata.Format(true));
