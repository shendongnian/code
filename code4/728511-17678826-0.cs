    public class Product:IDataErrorInfo
    {
        public string ProductName {get;set;}
        public string this[string propertyName]
        {
           get 
           {
               string validationResult = null;
               switch (propertyName)
               {
                   case "ProductName":
                   validationResult = ValidateName();
               }
           }
         }
    }
