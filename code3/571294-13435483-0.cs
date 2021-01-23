    public partial class MyForm : Form
    {
        private readonly ScriptEngine m_engine;
        private readonly ScriptScope m_scope;
        public MyForm()
        {
            InitializeComponent();
            m_engine = Python.CreateEngine();
            dynamic scope = m_scope = m_engine.CreateScope();
            // add this form to the scope
            scope.form = this;
            // add the proxy to the scope
            scope.proxy = CreateProxy();
        }
        // public so accessible from a IronPython script
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
        // private so not accessible from a IronPython script
        private int MyPrivateFunction()
        {
            MessageBox.Show("Called MyForm.MyPrivateFunction");
            return 42;
        }
        private object CreateProxy()
        {
            // let's expose all methods we want to access from a script
            dynamic proxy = new ExpandoObject();
            proxy.ShowMessage = new Action<string>(ShowMessage);
            proxy.MyPrivateFunction = new Func<int>(MyPrivateFunction);
            return proxy;
        }
    }
