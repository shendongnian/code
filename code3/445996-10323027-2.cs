        public partial class UserControl1 : UserControl
        {
            // we require a reference to the resource library to ensure it's loaded into memory
            private Class1 _class1 = new Class1();
            public UserControl1()
            {
                // Use the CultureManager to switch to the current culture
                CultureManager.UICulture = Thread.CurrentThread.CurrentCulture;
                InitializeComponent();
            }
        }
