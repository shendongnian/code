    @(if(Model.Customers.Items.Select(x => x.Id).Intersect(Model.Items.Select(x => x.Id)).Any())
    {
        Html.ActionLink("Remove from Library", "RemoveFromLibrary", new {id=item.Id});
    }
    else
    {
        Html.ActionLink("Add To Library", "AddToItems", new {id=item.Id});
    })
