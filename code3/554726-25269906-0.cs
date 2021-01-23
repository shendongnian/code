           private void MySQL_ToDatagridview()
        {
            //VarribleKeeper.MySQLConnectionString = your connection string
           //info being your table name
            MySqlConnection mysqlCon = new  
            MySqlConnection(VarribleKeeper.MySQLConnectionString);
            mysqlCon.Open();
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlSelectAll = "SELECT * from info";
            MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, mysqlCon);
            DataTable table = new DataTable();
            MyDA.Fill(table);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;
            dataGridView1.DataSource = bSource;
        }
