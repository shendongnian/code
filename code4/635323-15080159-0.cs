    DataSet ds = new DataSet();
    SqlDataAdapter sda = new SqlDataAdapter();
     SqlConnection sc = new SqlConnection("you connection string here Security=True");
       
    private void loadEmp()
            {
                try
                {
                    ds.Clear();
                    SqlCommand sCmd= new SqlCommand("Load your database, sc);
                    sda.SelectCommand = sCmd;
                    sda.Fill(ds, "sCmd");
                    datagrid.DataSource = ds.Tables["sCmd"];
                }
    
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.ExitThread();
                }
    
            }
