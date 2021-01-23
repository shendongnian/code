    @{
    List<SelectListItem> listItems= new List<SelectListItem>();
    listItems.Add(new SelectListItem
        {
          Text = "One",
          Value = "1"
        });
    listItems.Add(new SelectListItem
        {
            Text = "Two",
            Value = "2",
        });
    listItems.Add(new SelectListItem
        {
            Text = "Three",
            Value = "3"
        });
    listItems.Add(new SelectListItem
    {
       Text = "Four",
       Value = "4"
    });
    listItems.Add(new SelectListItem
    {
       Text = "Five",
       Value = "5"
    });
    }
    @Html.DropDownList("DDlDemo",new SelectList(listItems,"Value","Text"))
