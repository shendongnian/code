    @(if(Model.Library.Any(x => x.Id == x.ActionLinkItem))
    {
        Html.ActionLink("Remove from Library", "RemoveFromLibrary", new {id=item.Id});
    }
    else
    {
        Html.ActionLink("Add To Library", "AddToItems", new {id=item.Id});
    })
