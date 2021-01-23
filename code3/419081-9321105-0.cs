    [TestMethod()]
    public void GetRegistryKeyTest_Mocked()
	{
		IRegistryService target = CreateMockedRegistryService();
		string machineName = "localhost";
		RegistryHive hive = RegistryHive.LocalMachine;
		string path = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
		string valueName = "SystemRoot";
		object defaultValue = @"C:\Windows";
	
    	var keyMock = CreateMockedHKLM();
    	var remoteKeyMock = CreateMockedHKLM();
    	var subKeyMock = MockRepository.GenerateMock<IRegistryKey>();
    	subKeyMock.Stub(x => x.Name).Return(keyMock.Name + @"\" + path);
    	subKeyMock.Stub(x => x.GetValueNames()).Return(new string[] { valueName });
    	subKeyMock.Stub(x => x.GetValue(valueName)).Return(defaultValue);
    	remoteKeyMock.Stub(x => x.OpenSubKey(path)).Return(subKeyMock);
    	remoteKeyMock.Stub(x => x.GetValue(valueName)).Return(defaultValue);
    		
    	keyMock.Stub(x => x.OpenRemoteBaseKey(hive, machineName)).Return(remoteKeyMock);
    	target.ChangeBaseKey(keyMock);
    
    	actual = target.GetRegistryKey(machineName, hive, path, valueName, defaultValue);
    
    	Assert.AreEqual(expected.Results, actual.Results);
    	subKeyMock.AssertWasCalled(x => x.GetValue(valueName));
    }
