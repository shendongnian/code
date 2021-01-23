    public void setSQL()
    {
        string ConnStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\jasper\Desktop\AutoReg\AutoReg.accdb;";
        DataSet ds = new DataSet();
        
        //query to ask
        string query = "SELECT * FROM Student";
        
        using (OleDbConnection MyConn = new OleDbConnection(ConnStr))
        {
            MyConn.Open();
            
            using (OleDbCommand command = new OleDbCommand(query, MyConn))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                {
                    adapter.Fill(ds);                           
                }
            }
        }
        dataGridView1.DataSource = ds; 
    }
