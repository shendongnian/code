        protected override IDictionary<string, string> GetUserData(string accessToken)
        {
            var token = accessToken.EscapeUriDataStringRfc3986();
            FacebookGraphData graphData;
            var request = WebRequest.Create(string.Format("https://graph.facebook.com/me?access_token={0}", token));
            using (var response = request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    graphData = JsonHelper.Deserialize<FacebookGraphData>(responseStream);
                }
            }
            var userData = new Dictionary<string, string> {{"accessToken", accessToken}};
            userData.AddItemIfNotEmpty("id", graphData.Id);
            userData.AddItemIfNotEmpty("name", graphData.Name);
            userData.AddItemIfNotEmpty("email", graphData.Email);
            userData.AddItemIfNotEmpty("firstName", graphData.FirstName);
            userData.AddItemIfNotEmpty("lastName", graphData.LastName);
            userData.AddItemIfNotEmpty("link", graphData.Link == null ? null : graphData.Link.AbsoluteUri);
            userData.AddItemIfNotEmpty("username", graphData.Username);
            userData.AddItemIfNotEmpty("gender", graphData.Gender);
            userData.AddItemIfNotEmpty("locale", graphData.Locale);
            
            FacebookFriendData friendData;
            request = WebRequest.Create(string.Format("https://graph.facebook.com/me/friends?access_token={0}", token));
            using (var response = request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    friendData = JsonHelper.Deserialize<FacebookFriendData>(responseStream);
                }
            }
            if (friendData.Friends != null)
            {
                userData.Add("connections", friendData.Friends.Count().ToString());
            }
            return userData;
        }
