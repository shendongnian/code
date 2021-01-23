    class MyXmlFileWriter
    {
       public bool WriteData(string fileName, string xmlText)
       {   
          // TODO: Sort out exception handling
          try 
          {
             File.WriteAllText(fileName, xmlText);  
             return true; 
          } 
          catch(Exception ex) 
          { 
             return false; 
          }
       }
    }
