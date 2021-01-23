    var oid = new Oid("1.2.840.113549.1.7.2");
    ContentInfo contentInfo = new ContentInfo(oid, manifest);
    var signedCms = new SignedCms(contentInfo, true);
    var signer = new CmsSigner(SubjectIdentifierType.IssuerAndSerialNumber, myX509certificate);
    signer.IncludeOption = X509IncludeOption.EndCertOnly;
    signer.Certificates.Add(appleWwdrCertificate);
    // new requirement to add 'signing-date'
    signer.SignedAttributes.Add(new Pkcs9SigningTime(DateTime.Now));
    signedCms.ComputeSignature(signer);
    bytes[] signature = signedCms.Encode();
