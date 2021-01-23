    User userAlias = null;
   
    session.QueryOver<User>(() => userAlias)
        .WithSubquery.WhereValue(AccountStatus.DELETED).EqAll(QueryOver.Of<UserContainer>()
            .Where(uc => uc.User.Id == userAlias.Id)
            .Select(uc => uc.AccountStatus));
    // select list, more restrictions, etc.
        
