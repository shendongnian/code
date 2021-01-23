    public class EData<T> where T : EData<T>
    {
        public static T All(){
            return null;
        }
    }
    
    public class EHouse : EData<EHouse> 
    {
    
    }
