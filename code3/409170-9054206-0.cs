    public class BLFactory  
    {  
        public ISomeBL Create(IUser user)
        {              
            return new SomeBL(user);   
        }  
    }  
