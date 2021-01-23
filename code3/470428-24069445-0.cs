        static void Main(string[] args)
        {
            string pathFile = string.Empty;
            string designFile = string.Empty;
            //EDMX File location
            if (ConfigurationManager.AppSettings["EDMX"] != null)
            {
                pathFile = ConfigurationManager.AppSettings["EDMX"].ToString();
            }
            //Designer location for EF 5.0
            if (ConfigurationManager.AppSettings["EDMXDiagram"] != null)
            {
                designFile = ConfigurationManager.AppSettings["EDMXDiagram"].ToString();
            }
            XDocument xdoc = XDocument.Load(pathFile);
            const string CSDLNamespace = "http://schemas.microsoft.com/ado/2009/11/edm";
            const string MSLNamespace = "http://schemas.microsoft.com/ado/2009/11/mapping/cs";
            XElement csdl = xdoc.Descendants(XName.Get("Schema", CSDLNamespace)).First();
            XElement msl = xdoc.Descendants(XName.Get("Mapping", MSLNamespace)).First();
            #region CSDL
            foreach (var entitySet in csdl.Element(XName.Get("EntityContainer", CSDLNamespace)).Elements(XName.Get("EntitySet", CSDLNamespace)))
            {
                entitySet.Attribute("Name").Value = PascalCase(entitySet.Attribute("Name").Value);
                entitySet.Attribute("EntityType").Value = PascalCase(entitySet.Attribute("EntityType").Value);
            }
            foreach (var associationSet in csdl.Element(XName.Get("EntityContainer", CSDLNamespace)).Elements(XName.Get("AssociationSet", CSDLNamespace)))
            {
                foreach (var end in associationSet.Elements(XName.Get("End", CSDLNamespace)))
                {
                    end.Attribute("EntitySet").Value = PascalCase(end.Attribute("EntitySet").Value);
                }
            }
            foreach (var funtionSet in csdl.Element(XName.Get("EntityContainer", CSDLNamespace)).Elements(XName.Get("FunctionImport", CSDLNamespace)))
            {
                funtionSet.Attribute("Name").Value = PascalCase(funtionSet.Attribute("Name").Value);
               
            }
            foreach (var entityType in csdl.Elements(XName.Get("EntityType", CSDLNamespace)))
            {
                entityType.Attribute("Name").Value = PascalCase(entityType.Attribute("Name").Value);
                foreach (var key in entityType.Elements(XName.Get("Key", CSDLNamespace)))
                {
                    foreach (var propertyRef in key.Elements(XName.Get("PropertyRef", CSDLNamespace)))
                    {
                        propertyRef.Attribute("Name").Value = PascalCase(propertyRef.Attribute("Name").Value);
                    }
                }
                foreach (var property in entityType.Elements(XName.Get("Property", CSDLNamespace)))
                {
                    property.Attribute("Name").Value = PascalCase(property.Attribute("Name").Value);
                }
                foreach (var navigationProperty in entityType.Elements(XName.Get("NavigationProperty", CSDLNamespace)))
                {
                    navigationProperty.Attribute("Name").Value = PascalCase(navigationProperty.Attribute("Name").Value, true, true); 
                }
            }
            foreach (var association in csdl.Elements(XName.Get("Association", CSDLNamespace)))
            {
                foreach (var end in association.Elements(XName.Get("End", CSDLNamespace)))
                {
                    end.Attribute("Type").Value = PascalCase(end.Attribute("Type").Value);
                }               
                foreach(var refs in association.Elements(XName.Get("ReferentialConstraint", CSDLNamespace)))
                {
                    foreach (var pri in refs.Elements(XName.Get("Principal", CSDLNamespace)))
                    {
                        foreach (var proref in pri.Elements(XName.Get("PropertyRef", CSDLNamespace)))
                        {
                            proref.Attribute("Name").Value = PascalCase(proref.Attribute("Name").Value);
                        }
                    }
                    foreach (var pri in refs.Elements(XName.Get("Dependent", CSDLNamespace)))
                    {
                        foreach (var proref in pri.Elements(XName.Get("PropertyRef", CSDLNamespace)))
                        {
                            proref.Attribute("Name").Value = PascalCase(proref.Attribute("Name").Value);
                        }
                    }
                }
            }
            #endregion
            #region MSL
            foreach (var entitySetMapping in msl.Element(XName.Get("EntityContainerMapping", MSLNamespace)).Elements(XName.Get("EntitySetMapping", MSLNamespace)))
            {
                entitySetMapping.Attribute("Name").Value = PascalCase(entitySetMapping.Attribute("Name").Value);
                foreach (var entityTypeMapping in entitySetMapping.Elements(XName.Get("EntityTypeMapping", MSLNamespace)))
                {
                    entityTypeMapping.Attribute("TypeName").Value = PascalCase(entityTypeMapping.Attribute("TypeName").Value);
                    foreach
                    (var scalarProperty in
                    (entityTypeMapping.Element(XName.Get("MappingFragment", MSLNamespace))).Elements(XName.Get("ScalarProperty", MSLNamespace))
                    )
                    {
                        scalarProperty.Attribute("Name").Value = PascalCase(scalarProperty.Attribute("Name").Value);
                    }
                }
            }
            foreach (var associationSetMapping in msl.Element(XName.Get("EntityContainerMapping", MSLNamespace)).Elements(XName.Get("AssociationSetMapping", MSLNamespace)))
            {
                foreach (var endProperty in associationSetMapping.Elements(XName.Get("EndProperty", MSLNamespace)))
                {
                    foreach (var scalarProperty in endProperty.Elements(XName.Get("ScalarProperty", MSLNamespace)))
                    {
                        scalarProperty.Attribute("Name").Value = PascalCase(scalarProperty.Attribute("Name").Value);
                    }
                }
            }
            foreach (var functionSetMapping in msl.Element(XName.Get("EntityContainerMapping", MSLNamespace)).Elements(XName.Get("FunctionImportMapping", MSLNamespace)))
            {
                functionSetMapping.Attribute("FunctionImportName").Value = PascalCase(functionSetMapping.Attribute("FunctionImportName").Value);
            }
            #endregion
            xdoc.Save(pathFile);
            XmlDocument designXml = new XmlDocument();
          
            designXml.Load(designFile);      
            XmlNamespaceManager dsMan = new XmlNamespaceManager(designXml.NameTable);
            dsMan.AddNamespace("edmx", "http://schemas.microsoft.com/ado/2009/11/edmx");
            dsMan.AddNamespace("d", "http://schemas.microsoft.com/ado/2009/11/edmx");
            #region Designer
            XmlNodeList entitySet1 = designXml.DocumentElement.SelectNodes("//d:Diagrams", dsMan);
            foreach (XmlNode xn in entitySet1)
            {
                foreach (XmlElement xp in xn.ChildNodes)
                {
                    foreach (XmlElement z in xp.ChildNodes)
                    {
                        if (z.Attributes[0].Name == "EntityType")
                        {
                            z.Attributes[0].Value = PascalCase(z.Attributes[0].Value.ToString(), true);
                        }
                    }
                }
            }
            designXml.Save(designFile);
            #endregion
        }
        #region Pluralization
       
        public static string Pluralize(string name)
        {
     
       return System.Data.Entity.Design.PluralizationServices.PluralizationService.CreateService(new CultureInfo("en-US")).Pluralize(name);
        }
       
        #endregion
        #region Pascal Casing
        public static string PascalCase(StructuralType type, bool sanitizeName = true)
        {
            if (type == null)
            {
                return null;
            }
            return PascalCase(type.Name, sanitizeName);
        }
        public static string PascalCase(EdmMember member, bool sanitizeName = true)
        {
            if (member == null)
            {
                return null;
            }
            return PascalCase(member.Name, sanitizeName);
        }
        public static string PascalCase(string name, bool sanitizeName = true, bool pluralize = false)
        {
           // if pascal case exists
           // exit function
            Regex rgx = new Regex(@"^[A-Z][a-z]+(?:[A-Z][a-z]+)*$");
            string pascalTest = name;
            if (name.Contains("."))
            {
                string[] test  = new string[]{};
                test = name.Split('.');
                if(rgx.IsMatch(test[1].ToString()))
                {
                    return name;
                }
            }
            else
            {
                if (rgx.IsMatch(name))
                {
                    return name;
                }
            }
            
            //Check for dot notations in namespace
            bool contains = false;
            string[] temp = new string[] { };
            var namespc = string.Empty;
            if (name.Contains("."))
            {
                contains = true;
                temp = name.Split('.');
                namespc = temp[0];
            }
            if (contains)
            {
                name = temp[1];
            }
            name = name.ToLowerInvariant();
            string result = name;
            bool upperCase = false;
            result = string.Empty;
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == ' ' || name[i] == '_')
                {
                    upperCase = true;
                }
                else
                {
                    if (i == 0 || upperCase)
                    {
                        result += name[i].ToString().ToUpperInvariant();
                        upperCase = false;
                    }
                    else
                    {
                        result += name[i];
                    }
                }
            }
            if (contains)
            {
                result = namespc.ToString() + "." + result;
            }
            if (pluralize)
            {
                result = Pluralize(result);
            }
            return result;
        }
        #endregion
