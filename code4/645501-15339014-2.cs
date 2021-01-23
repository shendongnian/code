        if (!File.Exists(myFile))
        {
            MessageBox("Sorry buddy, that's a no-go.");
        }
        else
        {
            // Uh-oh! The file got deleted!
            File.Open(myFile);  // fails
        }
        
