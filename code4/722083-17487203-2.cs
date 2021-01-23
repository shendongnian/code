    public class Foo
    {
        public delegate void SelfDestroyer(object sender, EventArgs ea);
    
        public event SelfDestroyer DestroyMe;
    
        Timer t;
    
        public Foo()
        {
            t = new Timer();
            t.Interval = 2000;
            t.Tick += t_Tick;
            t.Start();
        }
    
        void t_Tick(object sender, EventArgs e)
        {
            OnDestroyMe();
        }
    
        public void OnDestroyMe()
        {
            SelfDestroyer temp = DestroyMe;
            if (temp != null)
            {
                temp(this, new EventArgs());
            }
        }
    }
    public class Bar
    {
        Foo foo;
        public Bar()
        {
            foo = new Foo();
            foo.DestroyMe += foo_DestroyMe;
        }
    
        void foo_DestroyMe(object sender, EventArgs ea)
        {
            foo.DestroyMe -= foo_DestroyMe;
            foo = null;
        }
    }
