            const int BadAuthenticationData = 215;
            var twitterCtx = new TwitterContext(auth);
            try
            {
                var account =
                    (from acct in twitterCtx.Account
                     where acct.Type == AccountType.VerifyCredentials
                     select acct)
                    .SingleOrDefault();
                await new MessageDialog(
                    "Screen Name: " + account.User.Identifier.ScreenName, 
                    "Verification Passed")
                    .ShowAsync();
            }
            catch (TwitterQueryException tqEx)
            {
                if (tqEx.ErrorCode == BadAuthenticationData)
                {
                    new MessageDialog(
                        "User not authenticated", 
                        "Error During Verification.")
                        .ShowAsync();
                    return;
                }
                throw;
            }
