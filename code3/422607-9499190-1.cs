	using Org.BouncyCastle.Asn1;
	using Org.BouncyCastle.X509;
	using Org.BouncyCastle.Asn1.X509;
	
	string GetMeTheOidThatIWant(byte[] certificate)
	{
		X509CertificateParser parser = new X509CertificateParser();
		X509Certificate cert1 = parser.ReadCertificate(certificate);
		X509Extension certPolicies =
			cert1.CertificateStructure.TbsCertificate.Extensions.GetExtension(X509Extensions.CertificatePolicies);
		DerSequence seq = certPolicies.GetParsedValue() as DerSequence;
		foreach (Asn1Encodable seqItem in seq)
		{
			DerSequence subSeq = seqItem as DerSequence;
			if (subSeq == null)
				continue;
			foreach (Asn1Encodable subSeqItem in subSeq)
			{
				DerObjectIdentifier oid = subSeqItem as DerObjectIdentifier;
				if (oid == null)
					continue;
				if (ThisIsTheOneIWant(oid))
					return oid.Id;
			}
		}
	}
