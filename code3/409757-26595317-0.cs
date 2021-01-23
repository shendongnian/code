	using System;
	using System.Security.Cryptography.X509Certificates;
	using PKI.OCSP;
	public class Class1 {
		public static DateTime? GetrevocationDate(X509Certificate2 cert) {
			OCSPRequest request = new OCSPRequest(cert);
			OCSPResponse response = request.SendRequest();
			if (response.Responses[0].CertStatus == CertificateStatus.Revoked) {
				return response.Responses[0].RevocationInfo.RevocationDate;
			}
			return null;
		}
	}
