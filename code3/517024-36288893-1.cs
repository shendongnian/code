    private static async void ReplaceAttributeValue(string editedFile, string attribteName, string attributeValueToReplace)
            {
                XmlDocument xmlDoc = new XmlDocument();
                await Task.Run(() => xmlDoc.Load(editedFile));
    
                var attributteToReplace = xmlDoc.FirstChild.Attributes?[attribteName];
    
                if (null != attributteToReplace)
                {
                    xmlDoc.FirstChild.Attributes[attribteName].Value = attributeValueToReplace;
                    xmlDoc.Save(editedFile);
                }
            }
