    if (session == null)
    {
        infoTextBlock.Text = "You must sign in first.";
    }
    else
    {
        Dictionary<string, object> folderData = new Dictionary<string, object>();
        folderData.Add("name", "A brand new folder");
        LiveConnectClient client = new LiveConnectClient(session);
        client.PostCompleted += 
            new EventHandler<LiveOperationCompletedEventArgs>(CreateFolder_Completed);
        client.PostAsync("me/skydrive", folderData);
    }
