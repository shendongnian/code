        abstract class MyBase
        {
          protected string _foo;
          protected MyBase(string foo) 
          {
             _foo = foo;
          }
        }
        
        class Child : MyBase
        {
            public Child()
            :base(string.Empty)
            {}
           public string Foo 
           {
            get 
            {
               return _foo;
             }
             set
             { 
               _foo = value;
              }
        }
    }
