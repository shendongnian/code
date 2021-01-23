    public static XDocument Patch(XDocument runtimeDocument, XDocument userDocument, string modulePath, string userName)
    {
    	XDocument patchDocument = new XDocument(userDocument);
    
    	foreach (XElement element in patchDocument.Element("patch").Elements())
    	{
                    // get id of the element
                    string idAttribute = element.Attribute(TARGET_ID_NAME).Value;
                    // get element with id from allUserDocument
                    XElement sharedElement = (from e in runtimeDocument.Descendants()
                                              where e.Attribute("id") != null 
                                                 && e.Attribute("id").Value.Equals(idAttribute)
                                              select e).FirstOrDefault();
    
                    // element doesn't exist anymore. Maybe the admin has deleted the element
                    if (sharedElement == null)
                    {
                        // delete the element from the user patch
                        element.Remove();
                    }
                    else
                    {
                        // set attributes to user values
                        foreach (XAttribute attribute in element.Attributes())
                        {
                            if (!attribute.Name.LocalName.Equals(TARGET_ID_NAME))
                            {
                                sharedElement.SetAttributeValue(attribute.Name, attribute.Value);
                            }
                        }
    
                        // set element value
                        if (!string.IsNullOrEmpty(element.Value))
                        {
                            sharedElement.Value = element.Value;
                        }
                    }
                }
    
    	// user patch has changed (nodes deleted by the admin)
    	if (!patchDocument.ToString().Equals(userDocument.ToString()))
    	{
                    // save back the changed user patch
                    using (PersonalizationProvider provider = new PersonalizationProvider())
                    {
                        provider.SaveUserPersonalization(modulePath, userName, patchDocument);
                    }
    	}
    
    	return runtimeDocument;
    }
