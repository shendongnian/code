    <% If Request.IsAuthenticated Then %>
      <!-- User is Logged In -->
      Welcome <b><%: Page.User.Identity.Name %></b>!
      [ <%: Html.ActionLink("Log Off", "LogOff", "Account")%> ]
    <% Else %>
      <!-- User is NOT Logged In -->
      Welcome <b>Guest</b> please login!
      [ <%: Html.ActionLink("Log On", "LogOn", "Account")%> ]
    <% End If %>
