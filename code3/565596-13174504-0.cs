    string path = Path.Combine(
    Environment.GetFolderPath(
    Environment.SpecialFolder.ApplicationData), 
    Application.CompanyName);
    
    path = Path.Combine(path, Application.ProductName);
    path = Path.Combine(path, subFolder);
    path = Path.Combine(path, "fileName.xml");
    
    if(!File.Exists(path)){
    	Assembly thisAssembly = Assembly.GetExecutingAssembly();
    	Stream rgbxml = thisAssembly.GetManifestResourceStream(
    "YourNamespace.fileName.xml");			
    	XmlDocument doc = new XmlDocument();
    	doc.Load(rgbxml);
    
    	doc.PreserveWhitespace = true;
    	doc.Save(path);
