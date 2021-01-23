    OleDbConnection con = new   
    OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data 
    Source=|DataDirectory|\productdb.mdb"
    String strSQL="Insert into [product](Kod, names, 
    price,type,volume,manufacturer,importer) values(@Kod,@names,@price,@type,
    @volume,@manufacturer,@importer)"
            OleDBCommand CmdSql= new OleDBCommand(strSQL, con);
            CmdSql.CommandType = CommandType.Text;
            CmdSql.Parameters.AddWithValue("@Kod", textBox1.Text);
            CmdSql.Parameters.AddWithValue("@names", textBox2.Text);
            CmdSql.Parameters.AddWithValue("@price", textBox3.Text);
            CmdSql.Parameters.AddWithValue("@type", textBox4.Text);
            CmdSql.Parameters.AddWithValue("@volume", textBox5.Text);
            CmdSql.Parameters.AddWithValue("@manufacturer", textBox6.Text);
            CmdSql.Parameters.AddWithValue("@importer", textBox7.Text);
            con.Open();
            try
            {
                 CmdSql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                con.Close();
                CmdSql.Dispose();
            }
