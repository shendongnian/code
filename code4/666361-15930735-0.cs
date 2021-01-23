    @Html.TextBoxFor(model => model.Username)
    @Html.PasswordBoxFor(model => model.Password, new { value = Model.Password })
    <ul id="roles">
    @for (int I = 0; I < Model.Roles.Count(); ++I)
    {
        <li>
            @Html.HiddenFor(model => Model.Roles[I].ID)
            @Html.CheckBoxFor(model => Model.Roles[I].RoleSelected)
            @Model.Roles[I].Name
        </li>
    }
    </ul>
