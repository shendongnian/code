       public void GetObjectData(dynamic myObject, string[] dataToGet) 
       {    
           List<string> dataToReturn = new List<string>();
           foreach (string propertyName in dataToGet)     
           {        
               try        
               {
                   dataToReturn.Add(Convert.ToString(myObject.propertyName));        
               }       
               catch 
               { dataToReturn.Add("");
               }    
           } 
       } 
