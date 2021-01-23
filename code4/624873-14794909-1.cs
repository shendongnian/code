    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private List<TabPage> tabPages;
        private void referenceDesk_DoubleClick(object sender, EventArgs e)
        {
            tabPages = new List<TabPage>();
            tabPages.Add(new TabPage("First"));
            tabPages.Add(new TabPage("Second"));
            foreach (var tab in tabPages)
                tabControl1.TabPages.Add(tab);
        }
        ....
    }
