    @model LoginRegisterViewModel
    @using (Html.BeginForm("Login", "Member", FormMethod.Post, new {})) {
        @Html.LabelFor(m => m.LoginUsername)
        @Html.TextBoxFor(m => m.LoginUsername)
        @Html.LabelFor(m => m.LoginPassword)
        @Html.TextBoxFor(m => m.LoginPassword)
        <input type='Submit' value='Login' />
    }
    @using (Html.BeginForm("Register", "Member", FormMethod.Post, new {})) {
        @Html.LabelFor(m => m.RegisterFirstName)
        @Html.TextBoxFor(m => m.RegisterFirstName)
        @Html.LabelFor(m => m.RegisterLastName)
        @Html.TextBoxFor(m => m.RegisterLastName)
        @Html.LabelFor(m => m.RegisterUsername)
        @Html.TextBoxFor(m => m.RegisterUsername)
        @Html.LabelFor(m => m.RegisterPassword)
        @Html.TextBoxFor(m => m.RegisterPassword)
        <input type='Submit' value='Register' />
