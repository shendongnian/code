    public class Movie : IDataErrorInfo
    {
       public int ID { get; set; }
    
      //other properties removed for clearyfication
    
           private string _lastError = "";
    
            public string Error
            {
                get { return _lastError; }
            }
    
            public string this[string columnName]
            {
                get 
                {
                   if(columnName == "ID" && ID < 0)
                     _lastError = "Id must be bigger that zero";
                }
            }
    
    }
