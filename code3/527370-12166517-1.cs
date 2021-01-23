    var path = Server.MapPath("~/Content/pathToYourFile.xml");           
    XElement elm = XElement.Load(path);
    if (elm != null)
    {
        foreach (var item in elm.Elements("class_table"))
        {
            string className = item.Element("class_title").
                                                  Element("class_name").Value;       
            
            foreach (var field in item.Element("fields").
                                                   Elements("field_name"))
            {
                string fieldName = field.Value;
            }
            foreach (var prop in item.Element("properties").
                                                        Elements("property_name"))
            {
                string propName = prop.Value;
            }
        }
    }
