    void Profile_Loaded(object sender, RoutedEventArgs e)
            {
                    int query = (from m in localaccount.account
                                 select m.PhoneNumber).First();
                    ProfileServiceClient profileClient = new ProfileServiceClient();
                    profileClient.profileCompleted += new EventHandler<profileCompletedEventArgs>(profileClient_profileCompleted);
                    profileClient.profileAsync(query);
                }
    
        void profileClient_profileCompleted(object sender, profileCompletedEventArgs e)
        {
            txtFirstName.Text = e.Result[0];
            txtLastName.Text = e.Result[1];
            txtLocation.Text = e.Result[2];
            txbGenre.Text = e.Result[3];
        }
