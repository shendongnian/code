         public void ListSubs()
                 {
                     string feedUrl = "http://gdata.youtube.com/feeds/api/users/" + username.Text + "/subscriptions";
                     YouTubeQuery query = new YouTubeQuery(feedUrl);
                     try
                     {
                         subFeed = service.GetSubscriptions(query);
                         foreach (SubscriptionEntry entry in subFeed.Entries)
                         {
                             string id = entry.Id.AbsoluteUri;
                             id = id.Substring(id.LastIndexOf(":")+1);
                             listBox1.Items.Add(id);
                             string usrname = entry.Content.Src.Content;
                             usrname = usrname.Substring(42);
                             usrname = usrname.Remove(usrname.LastIndexOf("/"));
                             listBox2.Items.Add(usrname);
                         }
                     }
                     catch(GDataRequestException e)
                     {
                         MessageBox.Show(e.ToString(), "Error:");
                     }
            
                 }
        public void UnSubUsers()
                {
                    YouTubeRequestSettings yts = new YouTubeRequestSettings("Unsubscriber", DEVELOPER_KEY, username.Text, password.Text);
                    YouTubeRequest request = new YouTubeRequest(yts);
                    int i = 0;
                    int x = 0;
                    x = (listBox1.Items.Count);
                    for (i=0;i<x ;i++ )
                    {
                        string uname = listBox1.Items[i].ToString();
                        yts = new YouTubeRequestSettings("Unsubscriber", DEVELOPER_KEY, username.Text, password.Text);
                        request = new YouTubeRequest(yts);
                        Subscription s = new Subscription();
                        s.Type = SubscriptionEntry.SubscriptionType.channel;
                        s.UserName = uname;
                        s.Id = listBox1.Items[i].ToString()
                        try
                        {
                            s.AtomEntry.EditUri = "http://gdata.youtube.com/feeds/api/users/" + username.Text + "/subscriptions" + "/" + listBox1.Items[i].ToString();
                            request.Delete(s);
                        }
                        catch (ArgumentNullException e)
                        {
                        }
                        catch (GDataRequestException e)
                        {
                        }
                    }
                }
