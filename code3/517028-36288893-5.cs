      /// <summary>
        /// Reason of using of this method: bug in workflow designer. When you save your xaml file, WF Designer assign "{x:Null}" to x:Class attribute
        /// Bug: In addition, if you want to set default value for your InArgument<T>, it defines attribute "this" (namespace declaration) with empty value. When you try to open your file, designer fails to parse XAML.
        /// </summary>
        /// <param name="editedFile"></param>
        /// <param name="attribteName"></param>
        /// <param name="attributeValueToReplace"></param>
        private static async Task CreateAttributeValue(string editedFile, string attribteName, string attributeValueToReplace)
        {
            XmlDocument xmlDoc = new XmlDocument();
            await Task.Run(() => xmlDoc.Load(editedFile));
            await Task.Run(() =>
            {
                var attributteToReplace = xmlDoc.FirstChild.Attributes?[attribteName];
                if (null != attributteToReplace)
                {
                    xmlDoc.FirstChild.Attributes[attribteName].Value = attributeValueToReplace;
                    xmlDoc.Save(editedFile);
                }
            });
        }
