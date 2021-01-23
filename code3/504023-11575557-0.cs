        public void Validate()
        {
            xmlDocChanges.Schemas.Add("", "xsd/Customization.xsd");
            ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationCallBack);
            xmlDocChanges.Validate(eventHandler);
        }
        public void ValidationCallBack (object sender, ValidationEventArgs args)
        {
            if(args.Severity == XmlSeverityType.Error || args.Severity == XmlSeverityType.Warning)
            {
                throw new Exception(args.Message);
            }
        }
