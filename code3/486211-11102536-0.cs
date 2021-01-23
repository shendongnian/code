    class BaseViewModel 
    {
        public BaseViewModel() {
         //stuff here
         }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
    
    class ActionOneViewModel : BaseViewModel 
    {
        public ActionOneViewModel (bool fooBar) : base() {
             FooBar = fooBar;
        }
        public bool FooBar { get; set; }
    }
    
    class ActionTwoViewModel : BaseViewModel 
    {
        public ActionTwoViewModel(string pingPong) :base() {
          PingPong = pingPong;
        }
        public string PingPong { get; set; }
    }
