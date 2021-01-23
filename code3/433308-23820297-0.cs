    @{
        var count = 0;
        foreach (var item in Model)
        {
            using(Html.TableRow(new { @class = (count++ % 2 == 0) ? "alt-row" : "" }))
            {
                <td>
                    @Html.DisplayFor(modelItem => item.Title)
                </td>
                <td>
                    @Html.Truncate(item.Details, 75)
                </td>
                <td>
                    <img src="@Url.Content("~/Content/Images/Projects/")@item.Images.Where(i => i.IsMain == true).Select(i => i.Name).Single()" 
                        alt="@item.Images.Where(i => i.IsMain == true).Select(i => i.AltText).Single()" class="thumb" />
                </td>
                <td>
                    @Html.ActionLink("Edit", "Edit", new { id=item.ProjectId }) |
                    @Html.ActionLink("Details", "Details", new { id = item.ProjectId }) |
                    @Html.ActionLink("Delete", "Delete", new { id=item.ProjectId })
                </td>
            }
        }
    }
