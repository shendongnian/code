     var encodedFieldName=XmlConvert.EncodeName(strContentTypeField);
                            // SharePoint fields are case sensitive , xmlconvert provides Hex characters in upper case while sharepoint stores in lowercase
                            encodedFieldName = Regex.Replace(encodedFieldName, @"[_][x][A-Fa-f0-9]+[_]", m =>m.ToString().ToLower());
                            if (!spList.Fields.ContainsField(encodedFieldName))
                            {
                                encodedFieldName = EncodeToInternalField(encodedFieldName);
                                if (!spList.Fields.ContainsField(encodedFieldName))
                                    continue;
                                strContentTypeField = encodedFieldName;
                            }
     private string EncodeToInternalField(string toEncode)
        {
            if (toEncode != null)
            {              
                StringBuilder encodedString = new StringBuilder();   
                foreach (char chr in toEncode.ToCharArray())
                {
                    string encodedChar = HttpUtility.UrlEncodeUnicode(chr.ToString());                   
                    
                    if (encodedChar == "+" || encodedChar == " ")
                    {
                        encodedString.Append("_x0020_");
                    }
                    else if (encodedChar == ".")
                    {
                        encodedString.Append("_x002e_");
                    }
                    else
                    {
                        encodedString.Append(chr);
                    }
                }
                return encodedString.ToString();
            }
            return null;
        }
