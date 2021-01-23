    public static string GetAttribute(ref XmlNode mynode, string AttributeName, string DefaultValue = "")
        {
            XmlAttribute myattr = default(XmlAttribute);
            string rtn = "";
            if (mynode != null)
            {
                myattr = mynode.Attributes[AttributeName];
                if (myattr != null)
                {
                    rtn = mynode.Attributes[AttributeName].Value;
                }
            }
            if (string.IsNullOrEmpty(rtn))
                rtn = DefaultValue;
            return rtn;
        }
