           public static DataSet DownDataBind()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=S1B01689;Initial Catalog=CosmosDB;User Id=sa;Password=Nttdata123");
                conn.Open();
               
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT id,categName from CM_Categories",conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                adapter.Dispose();
                conn.Close();
                return ds;
            }
            catch (Exception exp)
            {
                string s = exp.Message.ToString();
                return null;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
             
                DataSet ds = DownDataBind();
                comboBox1.DataSource = ds.Tables[0];// use Tables[0] instead of Table Name
                comboBox1.ValueMember = "Id";
                comboBox1.DisplayMember = "CategName";
                comboBox1.SelectedIndex = -1;
              
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            
        }
