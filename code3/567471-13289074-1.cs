	X509Certificate2 nonPersistentCert = CreateACertSomehow();
	// this is only required since there's no constructor for X509Certificate2 that uses X509KeyStorageFlags but a password
	// so we create a tmp password, which is not reqired to be secure since it's only used in memory
	// and the private key will be included (plain) in the final cert anyway
	const string TMP_PFX_PASSWORD = "password";
	// create a pfx in memory ...
	byte[] nonPersistentCertPfxBytes = nonPersistentCert.Export(X509ContentType.Pfx, TMP_PFX_PASSWORD);
	// ... to get an X509Certificate2 object with the X509KeyStorageFlags.PersistKeySet flag set
	X509Certificate2 serverCert = new X509Certificate2(nonPersistentCertPfxBytes, TMP_PFX_PASSWORD,
		X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable); // use X509KeyStorageFlags.Exportable only if you want the private key to tbe exportable
	// get the private key, which currently only the SYSTEM-User has access to
	RSACryptoServiceProvider systemUserOnlyReadablePrivateKey = serverCert.PrivateKey as RSACryptoServiceProvider;
	// create cspParameters
	CspParameters cspParameters = new CspParameters(systemUserOnlyReadablePrivateKey.CspKeyContainerInfo.ProviderType, 
		systemUserOnlyReadablePrivateKey.CspKeyContainerInfo.ProviderName, 
		systemUserOnlyReadablePrivateKey.CspKeyContainerInfo.KeyContainerName)
	{
		// CspProviderFlags.UseArchivableKey means the key is exportable, if you don't want that use CspProviderFlags.UseExistingKey instead
		Flags = CspProviderFlags.UseMachineKeyStore | CspProviderFlags.UseArchivableKey,
		CryptoKeySecurity = systemUserOnlyReadablePrivateKey.CspKeyContainerInfo.CryptoKeySecurity
	};
	// add the access rules
	cspParameters.CryptoKeySecurity.AddAccessRule(new CryptoKeyAccessRule(new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null), CryptoKeyRights.GenericRead, AccessControlType.Allow));
	// create a new RSACryptoServiceProvider from the cspParameters and assign that as the private key
	RSACryptoServiceProvider allUsersReadablePrivateKey = new RSACryptoServiceProvider(cspParameters);
	serverCert.PrivateKey = allUsersReadablePrivateKey;
	// finally place it into the cert store
	X509Store rootStore = new X509Store(StoreName.My, StoreLocation.LocalMachine);
	rootStore.Open(OpenFlags.ReadWrite);
	rootStore.Add(serverCert);
	rootStore.Close();
	// :)
