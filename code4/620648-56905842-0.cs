    // Errors and alerts collection
    private ICollection<string> errors = new List<String>();
    
    // Open xml and validate
    ...
    {
        // Create XMLFile for validation
        XmlDocument XMLFile = new XmlDocument();
        // Validate the XML file
        XMLFile.Validate(ValidationCallBack);
    }
    // Manipulator of errors occurred during validation
    private void ValidationCallBack(object sender, ValidationEventArgs args)
    {
        if (args.Severity == XmlSeverityType.Warning)
        {
            errors.Add("Alert: " + args.Message + " (Path: " + GetPath(args) + ")");
        }
        else if (args.Severity == XmlSeverityType.Error)
        {
            errors.Add("Error: " + args.Message + " (Path: " + GetPath(args) + ")");
        }
    }
