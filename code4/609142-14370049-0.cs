    MenuMain2 cont = (MenuMain2)LoadControl(@"../usercontrols/MenuMain2.ascx");
    ....
    if (name != null)
    {
        if (name.Equals("Jhon"))
        {
            cont.RootCategoryId = 1;
        }
        if (name.Equals("Bob"))
        {
            cont.RootCategoryId = 2;
        }
        if (name.Equals("Tom"))
        {
            cont.RootCategoryId = 3;
        }
    }
