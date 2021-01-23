        private void ConnectWithFacebook_Click(object sender, RoutedEventArgs e)
    {
        var fbLoginDialog = new FacebookLoginDialog(AppId, ExtendedPermissions);
        fbLoginDialog.ShowDialog();
        DisplayAppropriateMessage(fbLoginDialog.FacebookOAuthResult);
        if (fbLoginDialog.FacebookOAuthResult != null)
        {
            if (facebookOAuthResult.IsSuccess)
            {
                Console.WriteLine("You have successfully connected you Facebook account!");
            }
        }
    }
