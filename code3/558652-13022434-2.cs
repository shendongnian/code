    @model IEnumerable<Pro_Shot_Portal.ViewModels.SetAdminViewModel>
    @{
        ViewBag.Title = "Set Roles";
    }
    <h2>Index</h2>
    <table>
        <tr>
        <td>UserName</td>
        <td>Email</td>
        <td>Roles</td>
        </tr>
    @foreach (var item in Model) {
        <tr>
            <td>
                @Html.DisplayFor(modelItem => item.UserName)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Email)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Role)
            </td>
            <td>
                @if (@Html.DisplayFor(modelItem => item.Role).ToString() == "Administrator")
                {
                    @Html.ActionLink("Remove Admin", "RemoveAdmin", new { username = item.UserName })
                }
                else
                {
                    @Html.ActionLink("Add Admin", "AddAdmin", new { username = item.UserName })
                }
            </td>
        </tr>
    }
    </table>
