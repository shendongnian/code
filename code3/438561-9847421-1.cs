    @for (int i = 0; i < Model.AllRolles.Length; i++) 
    {
        @Html.CheckBoxFor(item => Model.AllRolles[i].IsActive)
        @Html.HiddenFor(item => Model.AllRolles[i].Role)
        @Html.Label(Model.AllRolles[i].Role)  
    }
