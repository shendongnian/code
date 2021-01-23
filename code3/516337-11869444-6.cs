    <%@ Page 
        Language="C#" 
        Inherits="System.Web.Mvc.ViewPage<MyViewModel>" 
    %>
    <% using (Html.BeginForm(null, null, FormMethod.Post, new { id = "myform", data_departments_url = Url.Action("Departments") })) { %>
        <div>
            <%= Html.LabelFor(x => x.SchoolId) %>
            <%= Html.DropDownListFor(
                x => x.SchoolId, 
                Model.SchoolList, 
                "-- School --",
                new { id = "school" }
            ) %>
        </div>
    
        <div>
            <%= Html.LabelFor(x => x.DepartmentId) %>
            <%= Html.DropDownListFor(
                x => x.DepartmentId, 
                Model.Departments,
                "-- Department --"
            ) %>
        </div>
    <% } %>
