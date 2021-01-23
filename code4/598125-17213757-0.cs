    public partial class EditPermit : Form
    {
         OleDbCommand command;
         OleDbDataAdapter da;
         private BindingSource bindingSource = null;
         private OleDbCommandBuilder oleCommandBuilder = null;
         DataTable dataTable = new DataTable();
        public EditPermit()
        {
            InitializeComponent();
        }
        private void EditPermitPermit_Load(object sender, EventArgs e)
        {
            DataBind();                           
        }
        private void btnSv_Click(object sender, EventArgs e)
        {
             dataGridView1.EndEdit(); //very important step
             da.Update(dataTable);
             MessageBox.Show("Updated");        
             DataBind(); 
        }
        private void DataBind()
        {
            dataGridView1.DataSource = null;
            dataTable.Clear();
            String connectionString = MainWindow.GetConnectionString(); //use your connection string please
            String queryString1 = "SELECT * FROM TblPermitType"; // Use your table please
            
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = queryString1;
            try
            {
                da = new OleDbDataAdapter(queryString1, connection);
                oleCommandBuilder = new OleDbCommandBuilder(da);
                da.Fill(dataTable);
                bindingSource = new BindingSource { DataSource = dataTable }; 
                dataGridView1.DataSource = bindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
              
        
        }
