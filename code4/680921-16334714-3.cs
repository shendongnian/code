    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            using (OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\New folder\Project 1.0\WebSite1\New Microsoft Office Access 2007 Database.accdb"))
            using (OleDbCommand cmd = new OleDbCommand("insert into Orders (Products, Amount) values (?,?)", con))
            {
                cmd.Parameters.AddWithValue("@p1", Label18.Text);
                cmd.Parameters.AddWithValue("@p2", int.Parse(Label16.Text));
                con.Open();
                int no = cmd.ExecuteNonQuery();
    
                Console.WriteLine("number of rows affected = " + no);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception Occured :" ex.ToString());
        }
    }
