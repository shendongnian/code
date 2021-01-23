            string name = null, type = null;
            string value = null;
            if (setting.Name.LocalName == "setting")
            {
                System.Xml.Linq.XAttribute xName = setting.Attribute("name");
                if (xName != null)
                {
                    name = xName.Value;
                }
                System.Xml.Linq.XAttribute xSerialize = setting.Attribute("serializeAs");
                if (xSerialize != null)
                {
                    type = xSerialize.Value;
                }
                System.Xml.Linq.XElement xValue = setting.Element("value");
                if (xValue != null)
                {
                    if (this[name].GetType() == typeof(System.Collections.Specialized.StringCollection))
                    {
                        foreach (string s in xValue.Element("ArrayOfString").Elements())
                        {
                            if (!((System.Collections.Specialized.StringCollection)this[name]).Contains(s))
                                ((System.Collections.Specialized.StringCollection)this[name]).Add(s);
                        }
                    }
                    else
                    {
                        value = xValue.Value;
                    }
                    if (this[name].GetType() == typeof(int))
                    {
                        this[name] = int.Parse(value);
                    }
                    else if (this[name].GetType() == typeof(bool))
                    {
                        this[name] = bool.Parse(value);
                    }
                    else
                    {
                        this[name] = value;
                    }
                }
            }`
