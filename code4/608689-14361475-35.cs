    public void Save(string fileName)
        {
            //skipping the foreach loop that re-builds the List from the Dictionary
            //Note: make sure when each AppSetting is created, you also set the pType field...use Value.GetType().ToString()
            XmlSerializer ser = new XmlSerializer(typeof(List<AppSetting>));
            FileStream fs = File.Open(fileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //get rid of those pesky default namespaces
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            ser.Serialize(sw, mySettings, ns);
            sw.Flush();
            sw.Close();
            fs.Close();
            mySettings = null;//no need to keep it around
        }
