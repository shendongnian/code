    private async Task UpdateButtonAsync(Task<bool> post)
    {
        if (!await post())
            ErrorBox.Text = "Error posting message.";
    }
    private void PostToTwitter()
    {
        UpdateButton(new TwitterAction().Post("Hello, world!"));
    }
