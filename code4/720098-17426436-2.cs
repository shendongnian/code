        public class Alice
        {
            public event Action<object> ValueChanged;
            protected void OnValueChanged(object arg)
            {
                Action<object> temp = ValueChanged;
                if (temp != null)
                {
                    temp (arg);
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
