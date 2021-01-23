    UpdateButton(()=>Post("ss"));
    private async void UpdateButton(Func<Task<bool>> post)
    {
        if (!await post())
            this.Text = "Error posting message.";
    }
    public virtual async Task<bool> Post(string messageId)
    {
        return await Task.Factory.StartNew(() => true);
    }
