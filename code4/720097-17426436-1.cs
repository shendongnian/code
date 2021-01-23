        public class Alice
        {
            public event Action<object> ValueChanged;
            protected void OnValueChanged(object arg)
            {
                if (ValueChanged != null)
                {
                    ValueChanged(arg);
                }
            }
        }
    
        public class Bob : Alice
        {
            public void method1()
            {
                object o = null;
                OnValueChanged(o);
            }
        }
