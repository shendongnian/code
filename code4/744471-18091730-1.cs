    public void OnAppStart()
    {
        string connString = null;
        try
        {
            connString = DataSource.ConnectionString;
        }
        catch (IOException ioe) 
        {
            MessageBox.Show("Hey, the file doesn't exist!");
        }
        catch (ArgumentNullException ane)
        {
            MessageBox.Show("Hey, the file is missing information!");
        }
        //You should be prepared to deal with a null or malformed connString 
        //from this point forwards
    }
