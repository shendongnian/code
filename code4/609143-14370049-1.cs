    MenuMain2 mn = (MenuMain2)LoadControl(@"../usercontrols/MenuMain2.ascx");
    ....
    if (name != null)
    {
        if (name.Equals("Jhon"))
        {
            mn.RootCategoryId = 1;
        }
        if (name.Equals("Bob"))
        {
            mn.RootCategoryId = 2;
        }
        if (name.Equals("Tom"))
        {
            mn.RootCategoryId = 3;
        }
    }
