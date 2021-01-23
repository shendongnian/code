    private void ReadFromDB()
    {
        // Read from database...
        // ...
        // Display and allow manipulation by user in a particular format
        txtDateTime.Text = dbData.CheckOutDate.ToString("yyyy-MM-dd HH:mm:ss");
    }
    private void WriteToDB()
    {
        // Value is "2013-02-06 10:11:43";
        dbData.CheckOutDate = DateTime.Parse(txtDateTime.Text);
        // ... etc ...
    }
