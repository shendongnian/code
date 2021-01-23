         #region x:Class and Argument<T> default value issues solution
                await CreateAttributeValue(_editedFile, ConstXClassAttributeName, typeof(App).Namespace + "." + Path.GetFileNameWithoutExtension(_editedFile));
                //should finish first operation before second operation begins to avoid I/O exception
                await CreateAttributeValue(_editedFile, ConstNamespaceAttributeName, ConstXamlClrNamespace + typeof(App).Namespace);
                await RepairArgsAttributes(_editedFile);
                    #endregion
    
    This is the methods definition:
     
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
     /// <summary>
            /// Bug in Workflow designer: workflow designer saves declaration for In/Out Arguments in invalid format. Means, that it is unable to open the same file it saved itself. This method fixes the Arguments declaration in XAML xmlns
            /// </summary>
            /// <param name="editedFile"></param>
            /// <returns></returns>
            private async Task RepairArgsAttributes(string editedFile)
            {
                XmlDocument xmlDoc = new XmlDocument();
                await Task.Run(() => xmlDoc.Load(editedFile));
    
                await Task.Run(() =>
                {
                    for (int i = 0; i < xmlDoc.FirstChild.Attributes.Count; i++)
                    {
                        if (xmlDoc.FirstChild.Attributes[i].Name.StartsWith(ConstInvalidArgStarts))
                        {
                            string innvalidAttrName = xmlDoc.FirstChild.Attributes[i].Name;//extraction of full argument declaration in xmlns
                            string[] oldStrings = innvalidAttrName.Split('.');//extraction of arguemnt name string
                            string localName = Path.GetFileNameWithoutExtension(editedFile) + "." + oldStrings[1];//build valid argment declaration without perfix
                            string valueBackup = xmlDoc.FirstChild.Attributes[i].Value;//saving of default value of Arguemnt<T>
                            xmlDoc.FirstChild.Attributes.RemoveNamedItem(xmlDoc.FirstChild.Attributes[i].Name);//removal of invalid Arguemnt declaration with default value. WARNING: when you remove attribue, at this moment you have another item at the place xmlDoc.FirstChild.Attributes[i]
                            //definition of new valid attribute requries: set separelly attribute prefix, localName (not "name" - it causes invalid attribute definition) and valid namespace url (in our case it's namespace deifinition in "this")
                            XmlAttribute attr = xmlDoc.CreateAttribute(ConstArgPrefix, localName, xmlDoc.FirstChild.Attributes[ConstNamespaceAttributeName].Value);
                            attr.Value = valueBackup;
                            xmlDoc.FirstChild.Attributes.InsertBefore(attr, xmlDoc.FirstChild.Attributes[i]);//define new correct Argument declaration attribute at the same place where was invalid attribute. When you put valid attribute at the same place your recover valid order of attributes that was changed while removal of invalid attribute declaration
                        }
                    }
                    xmlDoc.Save(editedFile);
    
                });
            }
