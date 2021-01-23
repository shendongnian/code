    public void loadXML()
    {
    	XDocument document = new XDocument();
    	
    	if(!FileInfo.Exists("MyXmlFile.xml")){
    		//Populate with data here if necessary, then save to make sure it exists
    		document.Save("MyXmlFile.xml");
    	}
        else{
            //We know it exists so we can load it
            document.load("MyXmlFile.xml");
        }
        
        //Continue to work with document
    
    }
