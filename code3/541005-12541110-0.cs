     <%@ Import Namespace="System.Web" %>
    void Application_Error(object sender, EventArgs e) {
 
       string message = Server.GetLastError().Message;
       Session["error"] = message;
       Server.Transfer("Error.aspx");
    }
