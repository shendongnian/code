    public partial class EditQuestionMaster : Form
        {
            DbHandling db = new DbHandling();
            int qid; // here is the class variable
            public EditQuestionMaster(int qid_value)
            {
                InitializeComponent();
                this.qid = qid_value; // set the value here
                string subNtop = db.GetEditSubNTopic(qid_value);
                string[] subNtopData = subNtop.Split('~');
                cmbSubject.Text = subNtopData[2];                
            }
    private void button1_Click(object sender, EventArgs e)
            {       
    
                qid // use it here
