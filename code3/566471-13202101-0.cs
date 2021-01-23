    public static bool HasPermission(this HtmlHelper helper, params Permission[] perms)
    {
        if (current user session has any permission from perms collection)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
