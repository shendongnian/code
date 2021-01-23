    <%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<System.Web.Mvc.HandleErrorInfo>" %>
    
    <asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    	ServerError
    </asp:Content>
    
    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
        <h2>ServerError</h2>
    
        <% if (Model.Exception != null ) { %>
    		<p>
    		  Controller: <%= Model.ControllerName %>
    		</p>
    		<p>
    		  Action: <%= Model.ActionName %>
    		</p>
    		<p>
    		  Message: <%= Model.Exception.Message%>
    		</p>
    		<p>
    		  Stack Trace: <%= Model.Exception.StackTrace%>
    		</p>
    	<% } %>
    
    </asp:Content>
