    public static XmlSchema LoadSchema(string pathname)
    {
        XmlSchema s = null;
        XmlValidationHandler h = new XmlValidationHandler();
        using (XmlReader r = XmlReader.Create(new FileStream(pathname, FileMode.Open)))
        {
            s = XmlSchema.Read(r, new ValidationEventHandler(h.HandleValidationEvent));
        }
        if (h.Errors.Count > 0)
        {
            throw new Exception(string.Format("There were {1} errors reading the XSD at {0}. The first is: {2}.", pathname, h.Errors.Count, h.Errors[0]));
        }
        return s;
    }
    
    public static XmlSchema LoadSchemaAndResolveIncludes(string pathname)
    {
        FileInfo f = new FileInfo(pathname);
        XmlSchema s = LoadSchema(f.FullName);
        foreach(XmlSchemaInclude i in s.Includes)
        {
            XmlSchema si = LoadSchema(f.Directory.FullName + @"\" + i.SchemaLocation);
            si.TargetNamespace = s.TargetNamespace;
            i.Schema = si;
        }
        return s;
    }
    public static List<ValidationEventArgs> Validate(string pathnameDocument, string pathnameSchema)
    {
        XmlSchema s = LoadSchemaAndResolveIncludes(pathnameSchema);
        XmlValidationHandler h = new XmlValidationHandler();
        XmlDocument x = new XmlDocument();
        x.Load(pathnameDocument);
        x.Schemas.Add(s);
        s.Compile(new ValidationEventHandler(h.HandleValidationEvent));
        x.Validate(new ValidationEventHandler(h.HandleValidationEvent));
        return h.Errors;
    }
