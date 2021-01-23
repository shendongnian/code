    public partial class Form3 : Form
    {
        List<DataRow> drlist = new List<DataRow>();
        DataTable dt = new DataTable();
    
        public Form3()
        {
            InitializeComponent();
        }
    
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
        private void btnNext_Click(object sender, EventArgs e)
        {
            ShowNext();
        }
    
        private void btnBack_Click(object sender, EventArgs e)
        {
            ShowPrev();
        }
    
        private void ShowNext()
        {
            Form4 formNext = new Form4();
            formNext.Show();
            this.Close();
        }
    
        private void ShowPrev()
        {
            Form2 formPrev = new Form2();
            formPrev.Show();
            this.Close();
        }
    
        private void Form3_Load(object sender, EventArgs e)
        {
           // blah blah.
        }
    }
