    var kp = [Org.BouncyCastle.Security.DotNetUtilities].GetKeyPair(rsaProvider);
    using (var sw = new System.IO.StringWriter())
    {
        var pw = new Org.BouncyCastle.OpenSsl.PemWrite(sw);
    	pw.WriteObject(kp.Public);
        var pem  = sw.ToString();
	    return pem;
    }
