      /// <summary>  
      /// Converts an XmlElement to an XElement.  
      /// </summary>  
      /// <param name="xmlelement">The XmlElement to convert.</param>  
      /// <returns>The equivalent XElement.</returns>  
      public static XElement ToXElement(XmlElement xmlelement)  
      {    
         return XElement.Load(xmlelement.CreateNavigator().ReadSubtree());  
      }
