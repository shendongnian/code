    if (Page.Request.QueryString["search"] != null && Page.Request.QueryString["search"].Length != 0)
                {
                    bool[] customString = new bool[5] { SearchCustomString1, SearchCustomString2, SearchCustomString3, SearchCustomString4, SearchCustomString5 };
                    string SearchString = RegStringZipper(Page.Request.QueryString["search"]);
                    //please note, given that I dont know what FabricProvider.Search works on, I dont actually know that this works as intended.
                    IList<Product> results = Fabric.ObjectProvider.Get<IProductSearchCommand>().Search(SearchString, out searchWords, IncludeSkus, IsPublicFacing, customString, CoreHttpModule.Session);
