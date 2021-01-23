    // This code opens and reads the contents of myFile.txt.
    private void btnRead_Click(object sender, RoutedEventArgs e)
    {
        // Obtain a virtual store for the application.
        IsolatedStorageFile myStore = IsolatedStorageFile.GetUserStoreForApplication();
    
        try
        {
            // Specify the file path and options.
            using (var isoFileStream = new IsolatedStorageFileStream("MyFolder\\myFile.txt", FileMode.Open, myStore))
            {
                // Read the data.
                using (var isoFileReader = new StreamReader(isoFileStream))
                {
                    txtRead.Text = isoFileReader.ReadLine();
                }
            }
    
        }
        catch
        {
            // Handle the case when the user attempts to click the Read button first.
            txtRead.Text = "Need to create directory and the file first.";
        }
    }
