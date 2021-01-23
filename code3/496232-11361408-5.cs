    @model MyViewModel
    @using (Html.BeginForm())
    {
        @Html.LabelFor(m => m.SelectedRole)
        @Html.DropDownListFor( m => m.SelectedRole, Model.Roles, "-- Role --")
        @Html.ValidationMessageFor(m => m.SelectedRole)
        <button type="submit">OK</button>
    }
