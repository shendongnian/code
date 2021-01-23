    public class MyClass : Form, IBindable
    {
        private BindingSource _Source = new BindingSource();
        public BindingSource Source { get { return _Source; } }
    }
