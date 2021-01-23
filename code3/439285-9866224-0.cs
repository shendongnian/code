      public class MyClass
        {
           int Option { get; set; }
           public void PerformOption(int option)
           {
              Option = option
              // other stuff
           }
        
           public void SomethingElse()
           {
             if(Option == 1)  // use Option at will
             {
             }
           }
    }
