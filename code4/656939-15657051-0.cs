    try
    {
        OleDbConnection vcon = new OleDbConnection(@"provider= microsoft.jet.oledb.4.0;data source=sample.mdb");
        vcon.Open();
        string test = string.Format("insert into inlog (PASSWORD, Username, leeftijd, gewicht) VALUES ('" + textBox2.Text + "','" + textBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')");
        OleDbCommand vcom = new OleDbCommand(test, vcon);
        vcom.ExecuteNonQuery();
        MessageBox.Show("Uw gegevens zijn opgeslagen");
    }
    catch(Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
    finally
    {
        vcom.Dispose();
        vcon.Close();
        vcon.Dispose();
    }
