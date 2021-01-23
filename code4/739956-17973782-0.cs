    private void Button_Click(object sender, RoutedEventArgs e)
    {
       //theMessageStatus is the message you want to post to FB/Twitter
       ShareNewsArticle(theMessageStatus);
    }
    private void ShareNewsArticle(string message)
    {
       ShareStatusTask sst = new ShareStatusTask();
       sst.Status = message;
       sst.Show();
    }
