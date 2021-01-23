    <%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CarTest.Controllers.Car>" %>
    
    <asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    	Index
    </asp:Content>
    
    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
        <%: Html.LabelFor(m => m.Id) %>
        <%: Html.TextBoxFor(m=> m.Id) %>
    
        <%: Html.LabelFor(m => m.Name) %>
        <%: Html.TextBoxFor(m=> m.Name) %>
    
        <%: Html.LabelFor(m => m.Colour) %>
        <%: Html.DropDownListFor(m=> m.Colour.Id, ViewData["Colours"] as IEnumerable<SelectListItem>) %>
    
    </asp:Content>
