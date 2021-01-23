        @Html.DropDownList("ActiveErrors", ListHelpers.PartsActive())
    public static List<SelectListItem> PartsActive()
    {
        List<SelectListItem> list = new List<SelectListItem>();
        list.Add(new SelectListItem { Text = "Yes", Value = "Y" });
        list.Add(new SelectListItem { Text = "All", Value = "A" });
        list.Add(new SelectListItem { Text = "No", Value = "N" });
        return list;
    }
