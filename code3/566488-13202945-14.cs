    public static bool AuthorizedAction(this HtmlHelper helper, string controller, string action)
    {
        var actions = GetActions(controller, action);
        var authorized = GetMyAuthorizations(actions);
        return user.Roles.Any(userrole => authorized.Roles.Any(role => role == userrole)) ||
           user.Permissions.Any(userPermission => authorized.Permissions.Any(permission => permission == userPermission))
    }
