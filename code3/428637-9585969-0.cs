    public class MyClass
    {
        private ParameterizedThreadStart starter;
        public MyClass()
        {
            starter = SelectJob;
            
            Del selectDelegate = SelectJob;
        }
        delegate void Del(string str);
        protected void SelectJob(object index)
        {
        }
    }
