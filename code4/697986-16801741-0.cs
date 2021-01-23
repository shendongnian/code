    delegate void MyDelegate(string message);
    
    class Foo
    {
        MyDelegate _delegate = null;
        int _count = 0;
    
        public event MyDelegate MySingleDelegateEvent
        {
            add
            {
                if (_count == 0)
                {
                    _delegate += value;
                    _count++;
                }
            }
            remove
            {
                if (_delegate != null)
                {
                    _delegate -= value;
                    _count--;
                }
            }
        }
    }
