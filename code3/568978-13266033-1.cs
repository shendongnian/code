    public class MyClass
    {
       private string _Item;
       public string Item 
       { 
           get { return _Item; }
           set 
           {
               if (_Item != value)
               {
                   _Item = value;
                   _ItemWithExtension = _Item + "_extension";
               }
           }
       }
       private string _ItemWithExtension;
       public string ItemWithExtension
       {
          get { return _ItemWithExtension; }
       }
    }
    var extended = 
               new List<MyClass>(from curItem in originals select 
                                new MyClass()
                                {
                                    Item = curItem
                                }
                               );
