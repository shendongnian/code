    public static UserState GetUserState(this HtmlHelper html)
    {
        var user = html.ViewContext.HttpContext.User;
        return MyModelLogic.GetUserState(user);
    }
</pre>
