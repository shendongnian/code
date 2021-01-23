    <%@ Control 
        Language="C#" 
        Inherits="System.Web.Mvc.ViewUserControl<GenSystem.Models.WeeklyModels>" 
    %>
    <%= Html.CheckBoxFor(m => m.IsChecked) %>
    <%= Html.LabelFor(m => m.IsChecked, Model.Name) %>
    <%= Html.HiddenFor(m => m.Name) %>
    <%= Html.HiddenFor(m => m.Value) %>
