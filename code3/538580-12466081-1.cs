    private async Task UpdateButtonAsync(Task<bool> post)
    {
        if (!await post())
            ErrorBox.Text = "Error posting message.";
    }
    // This will work if Post returns Task<bool> in the current API...
    private void PostToTwitter()
    {
        UpdateButtonAsync(new TwitterAction().Post("Hello, world!"));
    }
