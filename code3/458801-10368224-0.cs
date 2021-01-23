	using Org.BouncyCastle.X509;
	using Org.BouncyCastle.Security;
	using Org.BouncyCastle.Crypto;
	using Org.BouncyCastle.Crypto.Generators;
	using Org.BouncyCastle.Crypto.Parameters;
	
	...
	
	var generator = new RsaKeyPairGenerator ();
	generator.Init (new KeyGenerationParameters (new SecureRandom (), 1024));
	var keyPair = generator.GenerateKeyPair ();
	RsaKeyParameters keyParam = (RsaKeyParameters)keyPair.Public;
	var info = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo (keyParam);
	RsaBytes = info.GetEncoded ();
