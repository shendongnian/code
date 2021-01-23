    public class AppXmlLogWritter{
    
     
            public int RandomNumber {get;set}; //PUBLIC PROPERTY
    
    
            public AppXmlLogWritter()
            {
                Random random = new Random();
                RandomNumber = random.Next(9999);
                LogDateTime = DateTime.Now.ToString("yyyyMMdd HHmmss");
            }
    
         .... ..
         .... ..       
    
    }
