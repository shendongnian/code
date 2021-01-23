    public static string AuthorizedAction(this UrlHelper url, string controller, string action)
    {
        var actions = GetActions(controller, action);
        var authorized = GetMyAuthorizations(actions);
        if(user.Roles.Any(userrole => authorized.Roles.Any(role => role == userrole)) ||
           user.Permissions.Any(userPermission => authorized.Permissions.Any(permission => permission == userPermission)))
        {
            return url.Action(controller,action)
        }
        return string.empty;
    }
