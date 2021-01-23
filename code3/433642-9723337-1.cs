    void CreateFolder_Completed(object sender, LiveOperationCompletedEventArgs e)
    {
        if (e.Error == null)
        {
            infoTextBlock.Text = "Folder created.";
        }
        else
        {
            infoTextBlock.Text = "Error calling API: " + e.Error.ToString();
        }
    }
