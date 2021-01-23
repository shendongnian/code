        proxy.GetUserCompleted += new EventHandler<GetUserCompletedEventArgs (proxy_GetUserCompleted);
        proxy.GetUserAsync(1);
        //...
    }
    //...
    void proxy_CountUsersCompleted(object sender, CountUsersCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            userCountResult.Text = “Error getting the number of users.”; 
        }
        else
        {
            userCountResult.Text = "Number of users: " + e.Result;
        }
    }
