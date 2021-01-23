    @for(int i = 0; i < Model.RoleAccess.Count; i++)
                {
                    Html.CheckBoxFor(Model.RoleAccess[i].IsEnabled, new { id = Model.RoleAccess[i].MenuID });
                    Html.LabelFor(Model.RoleAccess[i].MenuDisplayName);
                }
