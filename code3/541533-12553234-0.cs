    public class MyBindingSource : BindingSource
    {
        private _myMethod = null;
        private MethodInfo MyMethod
        {
            get
            {
                if(_myMethod != null) return _myMethod;
                _myMethod = GetMyMethod();
            }
        }
        protected override void OnBindingComplete(BindingCompleteEventArgs e)
        {
        }
        void UseMyMethod (object value)
        {
            MyMethod.Invoke(SomeObject, new object[] { value });
        }
    }
