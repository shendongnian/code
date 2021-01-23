    private void Form1_Load(object sender, EventArgs e)
    {
        try
        {
            OleDbConnection connect = new OleDbConnection();
            connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Web Develop\Documents\Storekeeper\storekeeper.accdb;Persist Security Info=False;";
            connect.Open();
            MessageBox.Show("Connection open");
        }
        catch (OleDbException e)
        {
            Messagebox.Show(e.InnerException.Message);
        }
    }
