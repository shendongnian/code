    public void Load()
    {//Note: the assumption is that the app settings XML will be defined BEFORE this is called, and be under the same name every time.
        XmlSerializer ser = new XmlSerializer(typeof(List<AppSetting>));
        string fileName = Path.Combine(GetProperty("ConfigurationPath").ToString(), GetProperty("ConfigurationFile").ToString());
        FileStream fs = File.Open(fileName);
        StreamReader sr = new StreamReader(fs);
        mySettings = ser.DeSerialize(sr);
        sr.Close();
        fs.Close();
        //not showing simple foreach loop that will add all the properties to the dictionary
    }
