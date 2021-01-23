    public void OnAppStart()
    {
        string connString = null;
        try
        {
            connString = DataSource.ConnectionString;
        }
        catch (Exception e) //probably want to scope this to properly report the error
        {
            MessageBox.Show("Hey, I couldn't get the connection string!");
        }
    }
