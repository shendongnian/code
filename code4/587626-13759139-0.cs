    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tabControl1.Selecting += new tabControlCancelEventHandler(tabControl1_Selecting);
        }
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            // This blocks the user from opening the second tab
            if (e.Action == TabControlAction.Selecting && e.TabPageIndex == 1)
                e.Cancel = true;
        }
    }
