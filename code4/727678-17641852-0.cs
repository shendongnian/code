     public partial class Form3 : Form
        {
            private Form2 form2; // <--- you never initialize form2
            public Form3()
            {
                InitializeComponent();
                loadData();
            }
    
            public void loadData()
            {
                //UNHANDLED EXCEPTION HERE
                DataTable dt2 = form2.db.GetData(); 
                dgvScore.DataSource = dt2;
            }
    
        }
