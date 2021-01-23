    if (Page.PreviousPage != null)
    {
        if(Page.PreviousPage.IsCrossPagePostBack == true)
        {
            // and get the controls of the previous page as
            var SomeVariable = PreviousPage.DropDownlListId.SelectedValue;
        }
    }
