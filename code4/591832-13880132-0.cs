    public class A
    {
        public delegate void ExitDelegate(int a);
        public event ExitDelegate Exit;
        ...
        private void a_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnExit(100);
        }
        private void OnExit(int a)
        {
            // take a reference to the event (incase it changes)
            var handler = Exit;
            if (handler != null)
            {
                handler(a);
            }
        }
        
    }
    public class B
    {
        private A _a;
    
        public B()
        {
            _a = new A();
            _a.Exit += my_fun;
        }
        private void my_fun(int x)
        {
            if(x==100)
                do_smth;
            ...
        }
    }
