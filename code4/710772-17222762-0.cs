    Dictionary<string,string> fbParams = new Dictionary<string,string>();
                fbParams["message"] = Title;
                fbParams["caption"] = string.Empty;
                fbParams["description"] = string.Empty;
                fbParams["req_perms"] = "publish_stream";
                fbParams["scope"] = "publish_stream";
                //Initialize Your Facebook Client in the manner that suits you, I did it by supplying a saved access token from a single users
                FacebookWebClient fbClient = new FacebookWebClient(<YOUR_ACCOUNT_ACCESS_TOKEN>);
                //Get the listing of accounts associated with the user
                dynamic fbAccounts = fbClient.Get("/me/accounts");
                //Loop over the accounts looking for the ID that matches your destination ID (Fan Page ID)
                foreach (dynamic account in fbAccounts.data) {
                    if (account.id == <DESTINATION_ID_OF_YOUR_FAN_PAGE>) {
                        //When you find it, grab the associated access token and put it in the Dictionary to pass in the FB Post, then break out.
                        fbParams["access_token"] = account.access_token;
                        break;
                    }
                }
                //Then pass your destination ID and target along with FB Post info. You're Done.
                dynamic publishedResponse = fbClient.Post("/" + <DESTINATION_ID_OF_YOUR_FAN_PAGE> + "/feed", fbParams);
