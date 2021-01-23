    @if(Request.IsAuthenticated && User.IsInRole("Student") || 
    User.IsInRole("Administrator"))
    {
     @Html.ActionLink("Edit", "Edit", new { id = item.StdID })
    }
