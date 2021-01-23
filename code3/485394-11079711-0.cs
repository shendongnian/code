    using (IsolatedStorageFile isfInsuranceFirm = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly | IsolatedStorageScope.Domain, null, null))
    using (Stream stream1 = new IsolatedStorageFileStream("PageAccess.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None, isfInsuranceFirm))
    {
        stream1.Position = 0;
        string path1 = stream1.GetType().GetField("m_FullPath", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(stream1).ToString();
        string path2 = stream2.GetType().GetField("m_FullPath", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(stream2).ToString();
        XmlDataDocument doc = new XmlDataDocument();
        //doc.LoadXml(path1.Substring(path1.IndexOf('/') + 1));
        doc.Load(path1);
    }
