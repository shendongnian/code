    public class Singleton
    {
        public static Singleton Instance
        {
            get{ return sInstance;}
        }
        public void CallWcfMethod()
        {
            // ....
        }
    	
    	private static Singleton sInstance;
    }
