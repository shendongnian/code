        private void button1_Click(object sender, EventArgs e)
        {
            String name = "Items";
            String constr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                            "C:\\Sample.xls" + 
                            ";Extended Properties='Excel 12.0 XML;HDR=YES;';";
            OleDbConnection con = new OleDbConnection(constr);
            OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
            con.Open();
            OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
            DataTable data = new DataTable();
            sda.Fill(data);
            grid_items.DataSource = data;
        }
