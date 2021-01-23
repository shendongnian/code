    @model PagedList.IPagedList<PtoTracker.Employee>
    @{
    ViewBag.Title = "Employees";
    }
    <h2>Employees</h2>
    <p>
    @Html.ActionLink("Add New Employee", "Create")
    </p>
    <table>
    <tr>
        <th></th>
        <th></th>
    </tr>
    @foreach (var item in Model) {
    <tr>
        <td>
            @Html.DisplayFor(modelItem => item.EmployeeName)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", new { id=item.EmployeeID }) |
            @Html.ActionLink("Details", "Details", new { id=item.EmployeeID }) |
            @Html.ActionLink("Delete", "Delete", new { id=item.EmployeeID })
        </td>
    </tr>
    }
    </table>
    <div>
    Page @(Model.PageCount < Model.PageNumber ? 0 : Model.PageNumber)
    of @Model.PageCount
    @if (Model.HasPreviousPage)
    {
        @Html.ActionLink("<<", "Index", new { page = 1, sortOrder = ViewBag.CurrentSort });
        @Html.Raw(" ");
        @Html.ActionLink("< Prev", "Index", new { page = Model.PageNumber - 1, sortOrder = ViewBag.CurrentSort });
    }
    else
    {
        @:<<
        @Html.Raw(" ");
        @:< Prev
    }
    @if (Model.HasNextPage)
    {
        @Html.ActionLink("Next >", "Index", new { page = Model.PageNumber + 1, sortOrder = ViewBag.CurrentSort });
        @Html.Raw(" ");
        @Html.ActionLink(">>", "Index", new { page = Model.PageCount, sortOrder = ViewBag.CurrentSort });
    }        
    else
    {
        @:Next >
        @Html.Raw(" ");
        @:>>
    }
