            string result = string.Empty;`
           
                var node = doc.DocumentNode.SelectSingleNode("//input[@name='" + inputName + "']");
                if (node != null)
                {
                    result = node.Attributes[attrName].Value;
                }
            
            return result;
        }
