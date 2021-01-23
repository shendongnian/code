    <%@ Page Language="C#"%>
    <%
    for (int i = 0; i < Request.Cookies.Count; i++)
      {
        Response.Write(Request.Cookies[i].Name + " : ");
        Response.Write(Request.Cookies[i].Value);
        Response.Write("<br />");
      }
    %>
