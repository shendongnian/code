	using System;
	using System.Security.Cryptography.X509Certificates;
	public class Class1 {
		// crlRawData could a type of System.String and pass the path to a CRL file there.
		public static DateTime? GetrevocationDate(X509Certificate2 cert, Byte[] crlRawData) {
			X509CRL2 crl = new X509CRL2(crlRawData);
			X509CRLEntry entry = crl.RevokedCertificates[cert.SerialNumber];
			if (entry != null) {
				return entry.RevocationDate;
			}
			return null;
		}
	}
