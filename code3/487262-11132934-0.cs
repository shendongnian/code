    private void dataGridVies1_CellValidated(object sender, DataGridViewCellEventArgs e)
    {
            SqlCommandBuilder cb = new SqlCommandBuilder(sda);
            sda.Update(ds);
    }
    public partial class Form2 : Form
    {
           private void Form2_Load(object sender, EventArgs e)
        {
            con.ConnectionString = connectionstr;
            
            sda = new SqlDataAdapter("select * from table_user", con);//define dataadapter
            sda.Fill(ds );
            dataGridView1.DataSource = ds.Tables[0];//bind the data，now the datagridview can show up the data
            
        }
        string connectionstr = "integrated security=SSPI;Initial Catalog=****;Data Source=localhost;";//init
        SqlConnection con = new SqlConnection();//
        SqlDataAdapter sda = new SqlDataAdapter();//
        DataSet ds = new DataSet();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //you can not update sda here
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        private void dataGridVies1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            SqlCommandBuilder cb = new SqlCommandBuilder(sda);//auto generate the cmd of create, delete and update 
            sda.Update(ds);//flush to database
         }
      
    }
