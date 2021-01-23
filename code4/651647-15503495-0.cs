    public static class MyStaticBStreeInstance
    {
       public static BSTree Instance {get;private set;}
       static()
           {
              Instance = new BSTree<string>();
           }
    }
