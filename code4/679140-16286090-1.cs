    @model MyNamespace.Models.Register.SuperModel
    @{
        Layout = "~/Views/_Layout.cshtml";
    }
    
    @using (Html.BeginForm(null, null, FormMethod.Post, new { id = "myForm" }))
    {
       <div id="form">
           @Html.Partial("NameModel",@Model.Name.NameInfo)
       </div>
        @Html.TextBoxFor(m=>m.Register.UserName,new { @id="userName"})
        @Html.TextBoxFor(m=>m.Register.Password,new { @id="password"})
        <input type="submit" value="Register" id="btnRegister" />
    }
