    public class Foo
    {
        public delegate void MyEvent(object sender, object param);
        event MyEvent OnMyEvent;
        public Foo()
        {
            this.OnMyEvent += new MyEvent(Foo_OnMyEvent);
        }
        void Foo_OnMyEvent(object sender, object param)
        {
            if (this.OnMyEvent != null)
            {
                //do something
            }
        }
        
        void RaiseEvent()
        {
            object param = new object();
            this.OnMyEvent(this,param);
        }
    }
