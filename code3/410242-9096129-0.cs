    public partial class MyWindow : Window
    {
        public MyWindow()
        {
            InitializeComponent();
            Form winform = new Form();
            // to embed a winform using windowsFormsHost, you need to explicitly
            // tell the form it is not the top level control or you will get
            // a runtime error.
            winform.TopLevel = false;
            // hide border because it will already have the WPF window border
            winform.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.windowsFormsHost.Child = winform;
        }
    }
