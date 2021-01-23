    public static IRouteResolver RouteResolver(this Control control)
    {
        return ObjectFactory.With("control").EqualTo(control).GetInstance<IRouteResolver>();
    }
    public static IRouteResolver RouteResolver(this Page page)
    {
        return ObjectFactory.With("page").EqualTo(page).GetInstance<IRouteResolver>();
    }
