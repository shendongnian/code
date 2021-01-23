    public class Temp
    {
        string Property {get;set;}
    
        public Temp(string s)
        {
            Property = s;
            DoSomethingCommand = new DelegateCommand(x => DoSomething());
        }
    
        public DelegateCommand DoSomethingCommand {get;set;}
    
        private void DoSomething()
        {
            //DoSomething when the Button is Clicked!!
        }
    }
