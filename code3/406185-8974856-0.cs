    private static string getConfigFilePath()
    {
    	return Assembly.GetExecutingAssembly().Location + ".config";
    }
    private static XmlDocument loadConfigDocument()
    {
    	XmlDocument docx = null;
    	try
    	{
    		docx = new XmlDocument();
    		docx.Load(getConfigFilePath());
    		return docx;
    	}
    	catch (System.IO.FileNotFoundException e)
    	{
    		throw new Exception("No configuration file found.", e);
    	}
    }
    private void rem_CheckedChanged(object sender, EventArgs e)
    {
    	if (rem.Checked == true)
    	{
    		rem.CheckState = CheckState.Checked;
    		System.Xml.XmlDocument docx = new System.Xml.XmlDocument();
    		docx = loadConfigDocument();
    		System.Xml.XmlNode node;
    		node = docx.SelectSingleNode("//appsettings");
    		try
    		{
    			string key = "rem.checked";
    			string value = "true";
    			XmlElement elem = (XmlElement)node.SelectSingleNode(string.Format("//add[@key='{0}']", key));
    			if (elem != null)
    			{
    				elem.SetAttribute("value", value);
    			}
    			else
    			{
    			   elem = docx.CreateElement("add");
    				elem.SetAttribute("key", key);
    				elem.SetAttribute("value", value);
    				node.AppendChild(elem);
    			}
    			docx.Save(getConfigFilePath());
    		}
    		catch (Exception e2)
    		{
    			MessageBox.Show(e2.Message);
    		}
    	}	
    }			
