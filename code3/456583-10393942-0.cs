    public partial class Form1 : Form
    {
        //create connectionString variable
        const string conString = @"Data Source=.\SQLEXPRESS; Initial Catalog=DBTest; Integrated Security=SSPI;
        SqlConnection cn = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.getTableSchema();
        }
     //function to get the schemas from the Tables in MSSQLSERVER
        private void getTableSchema()
        {
            try
            {
                cn = new SqlConnection(conString);
                cn.Open();
                //call the getSchema Method of the SqlConnection Object passing in as a parameter the schema to retrieve
                 DataTable dt = cn.GetSchema("tables");
 
               //Binded the retrieved data to a DataGridView to show the results.
                this.dataGridView1.DataSource = dt;
                
          
            }
            catch (Exception)
            {
                throw;
            }
        }
       
    }
 
