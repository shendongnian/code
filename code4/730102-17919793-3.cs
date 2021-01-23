     <td>
       <% if this.User.IsAdminOrDomainAc(item.DomainAC) {%>
         <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
         <%: Html.ActionLink("Delete", "Delete", new { id=item.Id }) %>
       <% } %>
     </td>
