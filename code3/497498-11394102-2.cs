    <%@ Page 
        Title="" 
        Language="C#" 
        MasterPageFile="~/Views/Shared/ChildSite.Master" 
        Inherits="System.Web.Mvc.ViewPage<GenSystem.Models.WeeklyViewModel>" 
    %>
    
    <asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
        CreateWeekly
    </asp:Content>
    
    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <% using (Html.BeginForm()) { %>
            <div>
                <%= Html.EditorFor(m => m.Settings) %>
            </div>
            <br />
            <input value="GenerateForWeekly" name="submitButton" type="submit" />
        <% } %>
    </asp:Content>
