    public delegate void MyHandler(uint aEntityId);
    public class SimpleComponent: NativeComponent
    {
        public event MyHandler OnEnter;
        public event MyHandler OnExit;
        protected void CallOnEnter(uint aEntityId)
        {
            if (OnEnter != null)
                OnEnter(aEntityId);
        }
        protected void CallOnExit(uint aEntityId)
        {
            if (OnExit!= null)
                OnExit(aEntityId);
        }
    }
