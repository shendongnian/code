    class MyApplicationContext : ApplicationContext {
        //I'm using Lazy here, because an exception is thrown if any Forms have been
        //created before calling Application.SetCompatibleTextRenderingDefault(false)
        //in the Program class
        private static Lazy<MyApplicationContext> _current = new Lazy<MyApplicationContext>();
        public static MyApplicationContext Current {
            get {
                return _current.Value;
            }
        }
        public T CreateForm<T>() where T : Form, new() {
            var ret = new T();
            ret.FormClosed += onFormClosed;
            return ret;
        }
        private void onFormClosed(object sender, EventArgs e) {
            if (Application.OpenForms.Count == 0) {
                ExitThread();
            }
        }
        public MyApplicationContext() {
            //Any forms that should start with the application start, 
            //should be created / shown here
            var f1 = CreateForm<Form1>();
            f1.Show();
            var f2 = CreateForm<Form2>();
            f2.ShowDialog();
        }
    }
