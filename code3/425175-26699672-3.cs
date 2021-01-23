    RegistryKey localKey;
	if(Environment.Is64BitOperatingSystem)
		localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
	else
		localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
	string value = localKey.OpenSubKey("RSA").GetValue("WebExControlManagerPth").ToString();
