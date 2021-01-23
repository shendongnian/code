    class Program
    {
        
        static void Main(string[] args)
        {
            SecurityPermission t = new SecurityPermission(SecurityPermissionFlag.Execution);
            t.Demand();
            IsolationEntryPoint x = new IsolationEntryPoint();
            x.Enter(AppDomain.CurrentDomain);
        }
    }
    class IsolationEntryPoint : MarshalByRefObject
    {
        // main is the original AppDomain with all the permissions 
        public void Enter(AppDomain main)
        {
            // these work correctly 
            Console.WriteLine("Currently in: " + AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine("Host: " + main.FriendlyName);
            // the exception is thrown here 
            main.DoCallBack(this.MyCallBack);
        }
        public void MyCallBack()
        {
            Console.WriteLine("Currently in: " + AppDomain.CurrentDomain.FriendlyName);
        }
    }
