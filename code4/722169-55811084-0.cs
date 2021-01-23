C#
private static byte[] MergePFXFromPrivateAndCertificate(RSAParameters privateKey, X509Certificate2 certificate, string pfxPassPhrase)
{
	RsaPrivateCrtKeyParameters rsaParam = new RsaPrivateCrtKeyParameters(
		ParseAsUnsignedBigInteger(privateKey.Modulus),
		ParseAsUnsignedBigInteger(privateKey.Exponent),
		ParseAsUnsignedBigInteger(privateKey.D),
		ParseAsUnsignedBigInteger(privateKey.P),
		ParseAsUnsignedBigInteger(privateKey.Q),
		ParseAsUnsignedBigInteger(privateKey.DP),
		ParseAsUnsignedBigInteger(privateKey.DQ),
		ParseAsUnsignedBigInteger(privateKey.InverseQ)
	);
	Org.BouncyCastle.X509.X509Certificate bcCert = new Org.BouncyCastle.X509.X509CertificateParser().ReadCertificate(certificate.RawData);
	MemoryStream p12Stream = new MemoryStream();
	Pkcs12Store p12 = new Pkcs12Store();
	p12.SetKeyEntry("key", new AsymmetricKeyEntry(rsaParam), new X509CertificateEntry[] { new X509CertificateEntry(bcCert) });
	p12.Save(p12Stream, pfxPassPhrase.ToCharArray(), new SecureRandom());
	return p12Stream.ToArray();
}
private static BigInteger ParseAsUnsignedBigInteger(byte[] rawUnsignedNumber)
{
	return new BigInteger(1, rawUnsignedNumber, 0, rawUnsignedNumber.Length);
}
You will need the following namespaces:
C#
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
