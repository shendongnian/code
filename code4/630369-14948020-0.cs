    private void writeToXML()
    {
        // Method to write lines to XML file based on user input
        // Sets string variables
        string fileName = softwareNameTextBox.Text;
        string filePath = filePathTextBox.Text;
        string fileType = installerType.Text.ToString();
        string installSwitches = installSwitchesTextBox.Text;
    	
    	string FILE_PATH = "bla.xml";
    	
    	XDocument xDoc = XDocument.Load(FILE_PATH);
    	
    	xDoc.Root.Add(new XElement("software_entry",
    					new XAttribute("name", fileName),
    					new XAttribute("path", filePath),
    					new XAttribute("type", fileType),
    					new XAttribute("switches", installSwitches)
    				));
        xDoc.Save(FILE_PATH);
    }
