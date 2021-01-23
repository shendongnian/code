    public partial class Form1 : Form
    { 
        public Form1()
        {
            InitializeComponent();
        }
        private void btnViewList_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(**this**);
            f2.ShowDialog();
        }
    public partial class Form2 : System.Windows.Forms.Form
    {        
        private Form1 form1;
        public Form2(Form1 form1)
        {
            InitializeComponent();       
            this.form1 = form1;
        }
        ....
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lvlist.Items.Count < 1) { return; }
            **form1**.setFields(lvlist.FocusedItem.Text, lvlist.FocusedItem.SubItems[1].Text, lvlist.FocusedItem.SubItems[2].Text);
            this.Close();
        }
