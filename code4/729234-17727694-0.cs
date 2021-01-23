     case "&Change Values":
                    
     string attribute;
     string value;
     attribute = "";
     value = "";
     ChangeValues c = new ChangeValues();
     foreach (EA.Element theElement in myPackage.Elements)
     {
     foreach (EA.Attribute theAttribute in theElement.Attributes)
       {
       attribute = theAttribute.Name.ToString();
       value = theAttribute.Default.ToString();
       c.AddEntry(attribute, value);
       } 
     }
                    
     break;
