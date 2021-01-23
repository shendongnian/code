    @for(int i = 0; i < Model.RoleAccess.Count; i++)
    {
        Html.CheckBoxFor(Model.RoleAccess[i].IsEnabled, new { id = Model.RoleAccess[i].MenuID });
        Html.DisplayFor(Model.RoleAccess[i].MenuDisplayName); // or just Model.RoleAccess[i].MenuDisplayName
    }
