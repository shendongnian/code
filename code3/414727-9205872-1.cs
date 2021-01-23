    public void GetObjectData(MyClass myObject, string[] dataToGet) 
           {    
               List<string> dataToReturn = new List<string>();
    
               Type type = myObject.GetType(); 
    
               foreach (string propertyName in dataToGet)     
               {        
                   try        
                   {
                       PropertyInfo pInfo = type.GetProperty(propertyName);
                       var myValue = pInfo.GetValue(myObject, null); 
                       dataToReturn.Add(Convert.ToString(myValue));        
                   }       
                   catch 
                   { dataToReturn.Add("");
                   }    
               } 
           } 
