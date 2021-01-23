    int docid = int.Parse(label6.Text);
    String doctitle = label5.Text;
    var filledTextBoxes = this.Controls
                                 .OfType<TextBox>()
                                 .Select((txt,i) => new { Textbox = txt, Index = i })
                                 .Where(x => x.Textbox.Text.Length != 0);
    if(filledTextBoxes.Any())
    {
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            const String sql = "Insert Into exprmnt(docid,itemid,doctitle,itemcontent)values(@docid, @itemid, @doctitle, @itemcontent)";
            connection.Open();
            foreach(var txt in filledTextBoxes)
            {
                OledDbCommand cmd = new OledDbCommand(sql, connection);
                // Set the parameters.
                cmd.Parameters.Add(
                    "@docid", OleDbType.Integer).Value = docid;
                cmd.Parameters.Add(
                    "@doctitle", OleDbType.VarChar, 50).Value = doctitle;
                cmd.Parameters.Add(
                    "@itemid", OleDbType.Integer).Value = txt.Index;
                cmd.Parameters.Add(
                    "@itemcontent", OleDbType.VarChar, 100).Value = txt.Textbox.Text;
                try
                {
                    int affectedRecords = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } 
        } // The connection is automatically closed when the code exits the using block.
    }
    
