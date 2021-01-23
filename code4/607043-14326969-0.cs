    private async void btnSignIn_SessionChanged(object sender, Microsoft.Live.Controls.LiveConnectSessionChangedEventArgs e)
    {
        //if the user is signed in
        if (e.Status == LiveConnectSessionStatus.Connected)
        {
            session = e.Session;
            client = new LiveConnectClient(e.Session);
            infoTextBlock.Text = "Accessing SkyDrive...";
            //get the folders in their skydrive
            var result = await client.GetAsync("me/skydrive/files?filter=folders,albums");
            // Do here what you would normally do in btnSignin_GetCompleted
        }
        //otherwise the user isn't signed in
        else
        {
            infoTextBlock.Text = "Not signed in.";
            client = null;
        }
    }
