    public void uploadPhoto(Stream photoStream, string photoName)
    {
	var credentials = new OAuthCredentials
            {
                Type = OAuthType.ProtectedResource,
                SignatureMethod = OAuthSignatureMethod.HmacSha1,
                ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader,
                ConsumerKey = TwitterSettings.consumerKey,
                ConsumerSecret = TwitterSettings.consumerKeySecret,
                Token = TwitterSettings.accessToken,
                TokenSecret = TwitterSettings.accessTokenSecret,
                Version = "1.0a"
            };
            RestClient restClient = new RestClient
            {
                Authority = "https://upload.twitter.com",
                HasElevatedPermissions = true,
                Credentials = credentials,
                Method = WebMethod.Post
             };
             RestRequest restRequest = new RestRequest
             {
                Path = "1/statuses/update_with_media.json"
             };
             restRequest.AddParameter("status", tbxNewTweet.Text);
             restRequest.AddFile("media[]", photoName, photoStream, "image/jpg");
    }
        restClient.BeginRequest(restRequest, new RestCallback(PostTweetRequestCallback));
    }
    private void PostTweetRequestCallback(RestRequest request, Hammock.RestResponse response, object obj)
    {
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
		    //Success code
	        }
	}
