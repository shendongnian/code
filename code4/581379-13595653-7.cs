    public class Service
    {
        public event EventHandler<MouseEventArgs> fooEvent1 = delegate { };
        public event EventHandler<KeyEventArgs> fooEvent2 = delegate { };
        public void Fire()
        {
            fooEvent1(null, null);
            fooEvent2(null, null);
        }
    }
