    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private TabPage tabPage1, tabPage2;
        private void referenceDesk_DoubleClick(object sender, EventArgs e)
        {
            tabPage1 = new TabPage("First");
            tabPage2 = new TabPage("Second");
            tabControl1.TabPages.Add(tabPage1)
            tabControl1.TabPages.Add(tabPage2)
        }
        ....
    }
