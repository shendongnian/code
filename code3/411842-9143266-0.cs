    @model WebTestApplication.Models.ContainerObject
    
    @{
        ViewBag.Title = "TestForm";
        Layout = "~/Views/Shared/_Layout.cshtml";
    }
    
    @using (Html.BeginForm("TestFormResult", "Home", FormMethod.Post)) {
        @Html.EditorFor(m => m.Title)
        @Html.EditorFor(m => m.ObjectList);
    
        <input type="submit" value="Submit" />
    }
