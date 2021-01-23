        private void GraphApiSample()
        {
            var fb = new FacebookClient(_accessToken);
            fb.GetCompleted += (o, e) =>
            {
                if (e.Error != null)
                {
                    Dispatcher.BeginInvoke(() => MessageBox.Show(e.Error.Message));
                    return;
                }
                var result = (IDictionary<string, object>)e.GetResultData();
                Dispatcher.BeginInvoke(() =>
                {
                    ProfileName.Text = "Hi " + (string)result["name"];
                    FirstName.Text = "First Name: " + (string)result["first_name"];
                    FirstName.Text = "Last Name: " + (string)result["last_name"];
                });
            };
            fb.GetAsync("me"); 
        }
