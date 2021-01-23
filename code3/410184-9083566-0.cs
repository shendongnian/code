    public static string getValue(string nodename)
        {
            if (File.Exists(filename))
            {
                int i = 0;
                foreach (XmlNode xx in x.SelectNodes("//" + nodename))
                {                   
                    if (xx.HasChildNodes && xx.ChildNodes[i].NodeType == XmlNodeType.Element)
                        return getValue(nodename + "//" + xx.ChildNodes[i].Name);//i'm sure it should return value
                    else
                        return xx.InnerText;
                    i++;
                }
            }
            return null;
        }
