    public class SomeModel
    {
        private string someString = "";
    
        public string SomeString {
            get { return this.someString; }
            set {
                this.someString = value;
                this.DoSomeWork();
            }
        }
    
       public void DoSomeWork()
       {
          ....
       }
    }
