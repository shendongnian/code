    public class A
    {
        public delegate void ExitHandler(object sender, int a);
        public event ExitHandler Exit;
        ...
        private void a_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnExit(100);
        }
        protected virtual void OnExit(int a)
        {
            // take a reference to the event (incase it changes)
            var handler = Exit;
            if (handler != null)
            {
                handler(this, a);
            }
        }
        
    }
    public class B
    {
        private A _a;
    
        public B()
        {
            _a = new A();
            _a.Exit += (sender, value) => my_fun(value);
        }
        private void my_fun(int x)
        {
            if(x==100)
                do_smth;
            ...
        }
    }
