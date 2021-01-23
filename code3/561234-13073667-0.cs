    XmlDocument xmlSnippet = new XmlDocument();
     xmlSnippet.Load(@"C:\Working Directory\OGCSOS.Service\OGCSOS.Service\Resources\GetObservation_TemporalFilter.xml");
    
     //Selects all the similar nodes by tag Name.......
                   XmlNodeList xmlSnippetNodes = xmlSnippet.GetElementsByTagName("fes:After");
    
     //Checking if any any xmlSnippetNode has matched.
                   if (xmlSnippetNodes != null)
                   {
                       //Checks if the matched xmlSnippetNode that has fes:After attribute is not  NULL
      
    
    //Stores the value of the matched tag.
                              var valueReference= xmlSnippetNodes.Item(0).Value;
    
                       var timeInstance=xmlSnippetNodes.Item(1).Attributes["gml:id"].Value;
                     var timePosition =xmlSnippetNodes.Item(1).InnerXml.Name;
    
        
                               //Return True if updated correctly.
                               isUpdated = true;
                           
        
                       }
