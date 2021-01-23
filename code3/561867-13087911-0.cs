       private void button2_Click(object sender, EventArgs e) 
       {
            DataRetriever dr = new DataRetriever();
            DataSet fg = dr.GetData(comboBox.Text);
            label1.Text = "No. of Rows:-    " + fg.Tables[0].Rows.Count.ToString();
            dataGridView1.DataSource = fg.Tables[0];
        }
    public class DataRetriever
    {
        public void GetData(string text)
        {
            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=c://library//lib.mdb");
            OleDbDataAdapter cmd = new OleDbDataAdapter("select * from entry where LTRIM(subjet)=?", cn);
            cmd.SelectCommand.Parameters.AddWithValue("1", text);
            DataSet fg = new DataSet();
            cmd.Fill(fg);
       }
    }
