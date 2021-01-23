    public partial class Form1 : Form
    {
        // We need an instance of the filter class
        KeyMessageFilter filter;
        public Form1()
        {
            InitializeComponent();
            filter = new KeyMessageFilter(panel1);
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
