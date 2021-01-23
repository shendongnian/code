    public partial class Form1 : Form
    {
        // We need an instance of the filter class
        KeyMessageFilter filter = new KeyMessageFilter();
        public Form1()
        {
            InitializeComponent();
            // add the filter
            Application.AddMessageFilter(filter);
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            // remove the filter
            Application.RemoveMessageFilter(filter);
        }
    }
