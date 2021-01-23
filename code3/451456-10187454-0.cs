    public class Foo
        {
             private ObservableCollection<string> _names;
             public ObservableCollection<string> Names 
             { 
                 get{ return _names;} 
                 set
                 { 
                      _names = value;
                      
                 } 
             }
        }
