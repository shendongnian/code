    var truthTable = List<Tuple<NavigationTab, Role, Action>>
    {
        new Tuple<NavigationTab, Role, Action>(NavigationTab.Users, Role.UsersAdministration, MVC.Administration.Users.Index()),
        new Tuple<NavigationTab, Role, Action>(NavigationTab.Users, Role.RolesAdministration, MVC.Administration.Roles.Index()),
        new Tuple<NavigationTab, Role, Action>(NavigationTab.Products, Role.ProductsAdministration, MVC.Administration.Products.Index()),
    }
