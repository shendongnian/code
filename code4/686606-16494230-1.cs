    public Form1()
    {
        try
        {
            DBInfo db = new  DBInfo();
            // do stuff with DBInfo object like db.GetConnection() etc...
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
