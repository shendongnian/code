    <td>
        <% if (User.IsInRole("Administrators") || User.Identity.Name == item.DomainAC) { %>
            <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
            <%: Html.ActionLink("Details", "Details", new { id=item.Id }) %> |
            <%: Html.ActionLink("Delete", "Delete", new { id=item.Id }) %>
        <% } %>
    </td>
    public ActionResult Edit(int id) {
        var user = GetUserById(id);
        if (!User.IsInRole("Administrators") && User.Identity.Name != user.DomainAC) {
            // unauthorized
        }
        // authorized - continue
    }
