    public partial class Form1 : Form
    {
        Label label = new Label() { Text = "Hello World" };
        public Form1()
        {
            InitializeComponent();
            tabControl1.TabPages[0].Controls.Add(label);
        }
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            e.TabPage.Controls.Add(label);
            e.TabPage.Controls.SetChildIndex(label, 0);
        }
    }
