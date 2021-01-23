    private void loadXML()
    {
        var someClass = new SomeClass();
        
        if (configFilePathTextBox.Enabled == true)
        {
            someClass.document = XDocument.Load(configFilePathTextBox.Text);
        }
        else
        {
            someClass.document = XDocument.Load(Application.StartupPath + @"\config.xml");
        }
        IEnumerable<XElement> elList =
            from el in config.Descendants("software_entry")
            select el;
        foreach (XElement el in elList)
            listBox1.Items.Add(el.Attribute("name"));
        MessageBox.Show("Configuration file loaded successfully.");
    }
