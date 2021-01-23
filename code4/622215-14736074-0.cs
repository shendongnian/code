    var twitterCtx = new TwitterContext(auth);
    (from social in twitterCtx.SocialGraph
     where social.Type == SocialGraphType.Followers &&
           social.ScreenName == "JoeMayo"
     select social)
    .MaterializedAsyncCallback(asyncResponse =>
         Dispatcher.BeginInvoke(() =>
         {
             if (asyncResponse.Status != TwitterErrorStatus.Success)
             {
                  MessageBox.Show(
                      "Error during query: " + 
                      asyncResponse.Exception.Message);
                  return;
             }
             SocialGraph social = asyncResponse.State.SingleOrDefault();
             SocialListBox.ItemsSource = social.IDs;
         }));
