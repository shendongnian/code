    public interface iMyDataManager
    {  
       stuff ... 
    }
    
    public class MyDataManager<T> : iMyDataManager
    {  
       implementation ... that I want common to all derived specific instances 
    }
    
    
    public class MySpecificDataInstance : MyDataManager<MySpecificDataInstance>
    {
       continue with rest of actual implementations specific to this class.
    }
