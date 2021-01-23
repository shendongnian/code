    private void UserInfo(string userName, string userEmail, string imageURL)
    {
        WebClient client = new WebClient();
        byte[] imgData = client.DownloadData(imageURL);
        // store imgData in database
    }
