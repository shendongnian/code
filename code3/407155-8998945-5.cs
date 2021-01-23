    @model ChooseRoleModel
    
    @using (Html.BeginForm())
    {
        <div>
            @Html.LabelFor(x => x.Username)
            @Html.EditorFor(x => x.Username)
        </div>
        for (int i = 0; i < Model.Roles.Length; i++)
    	{
            @Html.CheckBoxFor(x => x.Roles[i].Selected)    
            @Html.LabelFor(x => x.Roles[i].Selected, Model.Roles[i].Text)
            @Html.HiddenFor(x => x.Roles[i].Text)
        }
        <button type="submit">OK</button>
    }
