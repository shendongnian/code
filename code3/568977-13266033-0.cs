    public class MyClass
    {
       public string Item { get; set; }
       public string ItemWithExtension
       {
          get { return Item + "_extension"; }
       }
    }
    var extended = 
               new List<MyClass>(from curItem in originals select 
                                new MyClass()
                                {
                                    Item = curItem + "_extension"
                                }
                               );
