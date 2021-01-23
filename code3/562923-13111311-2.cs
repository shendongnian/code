    @model CheckBoxViewModel
    
    @{
        var index = Guid.NewGuid().ToString();
    }
    
    @Html.Hidden("list.Index", index)
    @Html.Hidden("list[" + index + "].Id", Model.Id)
    @Html.Hidden("list[" + index + "].Name", Model.Name)
    @Html.CheckBox("list[" + index + "].CheckBox", Model.CheckBox)
