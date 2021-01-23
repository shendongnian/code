    if (Page.PreviousPage != null)
    {
        if(Page.PreviousPage.IsCrossPagePostBack == true)
        {
            // here you can get from Page2.aspx==PreviousPage
            //  a check box check, what ever you like...
            GetTheClass = PreviousPage.MyDataClass;
        }
    }
