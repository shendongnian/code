     private void Count_button_Click(object sender, EventArgs e)
        {
            using (OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data     Source=XXX.mdb"))
            using (OleDbCommand Command = new OleDbCommand(" SELECT count (CustomerID) from tblCustomer as total", con))
            {
                con.Open();
                OleDbDataReader DB_Reader = Command.ExecuteReader();
                if (DB_Reader.HasRows)
                {
                    DB_Reader.Read();
                    textbox1.Text = DB_Reader.GetInt("total");
                }
            }
        }
