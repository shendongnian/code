    public class contextA : DbContext
    {
       public contextA()
       {
          Configuration.ProxyCreationEnabled = false;
       }
    }
