    @foreach (RoleAccessViewModel mnu in Model.RoleAccess)
    {
        @Html.CheckBoxFor(m => mnu.IsEnabled )
    }
    
