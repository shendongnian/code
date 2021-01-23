    public static class MyConfig
    {
       static private BSTree<string> record = new BSTree<string>();
       static public BSTree<string> Record
       {
           get {return record;}
           set {record = value;}
       }
       ...
    }
