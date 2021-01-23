    public override void CreateOrUpdateOAuthAccount(string provider, string providerUserId, string userName)
    {
        this.VerifyInitialized();
        if (userName.IsEmpty())
        {
            throw new MembershipCreateUserException(MembershipCreateStatus.ProviderError);
        }
        int userId = this.GetUserId(userName);
        if (userId == -1)
        {
            throw new MembershipCreateUserException(MembershipCreateStatus.InvalidUserName);
        }
        int userIdFromOAuth = this.GetUserIdFromOAuth(provider, providerUserId);
        using (IDatabase database = this.ConnectToDatabase())
        {
            if (userIdFromOAuth == -1)
            {
                if (database.Execute("INSERT INTO [" + OAuthMembershipTableName + "] (Provider, ProviderUserId, UserId) VALUES (@0, @1, @2)", new object[] { provider, providerUserId, userId }) != 1)
                {
                    throw new MembershipCreateUserException(MembershipCreateStatus.ProviderError);
                }
            }
            else if (database.Execute("UPDATE [" + OAuthMembershipTableName + "] SET UserId = @2 WHERE UPPER(Provider)=@0 AND UPPER(ProviderUserId)=@1", new object[] { provider, providerUserId, userId }) != 1)
            {
                throw new MembershipCreateUserException(MembershipCreateStatus.ProviderError);
            }
        }
    }
