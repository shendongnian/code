    public static class MyStaticBStreeInstance
    {
       public static BSTree Instance {get;private set;}
       static MyStaticBStreeInstance()
           {
              Instance = new BSTree<string>();
           }
    }
