    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGrid1.PreferredRowHeight = 64;
            myTableAdapter.Fill(myDataSet.myTable);
        }
    }
