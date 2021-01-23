    <%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Nullable<System.DateTime>>" %>
    <% if ( Model.HasValue )
       { %>
        <%: Html.TextBox( "" , String.Format( "{0:ddd, MMM d, yyyy}" , Model.Value )  )%>
    <% }
       else
       { %>
       <%: Html.TextBox( "" , String.Format( "{0:ddd, MMM d, yyyy}" , DateTime.Now )  )%>
    <% } %>
