    namespace WcfService5
    {
    
        [ServiceContract]
        public interface IService1
        {
    
            [OperationContract]
            Boolean UploadPhoto(data fileContents);
    
          
        }
    
    [Serializable]
    public struct data 
    {
        System.IO.Stream mystream;
        string ereport;
        string reporttype;
    
    
    }
    
    
         
    }
