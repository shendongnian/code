        public void Save() {
        
            XDocument xDoc = new XDocument(new XDeclaration("Version", "Unicode type", null));
            XElement root = new XElement("GenericList");
            //For this example we are using a Schema to validate our XML
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", HostingEnvironment.MapPath("RelativeFilepath"));
            foreach (GenericItem item in genericList) {
            
                root.Add(
                    //Assuming XML has a structure as such
                    //<GenericItem>
                    //  <name></name>
                    //  <id></id>
                    //</GenericItem>
                    new XElement("GenericItem",                        
                            new XElement("name", item.name),
                            new XElement("id", item.id)
                    ));
            }
            xDoc.Add(root);
            //This is where the mentioned schema validation takes place
            string errors = "";
            xDoc.Validate(schemas, (obj, err) => {
                errors += err.Message + "/n";
            });
              
            StringWriter writer = new StringWriter();
            XmlWriter xWrite = XmlWriter.Create(writer);
            xDoc.Save(xWrite);
            xWrite.Close();
            if (errors == "")
            {
                xDoc.Save(HostingEnvironment.MapPath("RelativeFilepath"));
            }
        }
