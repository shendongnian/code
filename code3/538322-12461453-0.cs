    public static void RegisterRoutes(RouteCollection routes)
    {
     routes.Ignore("{*sliderimages}", new { sliderimages =@"slider/\d+\.jpg"});
     routes.MapPageRoute("CategoryRoute", "Category/{sCatId}", "~/Category.aspx",true);
     routes.MapPageRoute("SubCategoryRoute", "SubCategory/{catid}",   "~/SubCategory.aspx");
    }
