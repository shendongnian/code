    class A {
        Form1 form;
        public A()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new Form1();
            form.Show();
            Application.Run(form);
        }
    }
    [STAThread]
    static void Main()
    {
        A a = new A();
    }
