    private void StartButton_Click(object sender, EventArgs args)
    {
        StartButton.Enabled = false;
        try
        {
            for (int i = 0; i < 50; i++)
            {
                string line = file.ReadLine();
                //Send to server
            }
        }
        finally
        {
            StartButton.Enabled = true;
        }
    }
