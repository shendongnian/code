    @{
        ViewContext.FormContext = new FormContext();
    }
    
    @Html.LabelFor(xModels => xModels.SelectedChannelID)
    @Html.DropDownListFor(
        x => x.SelectedChannelID, 
        Model.ChannelSelectList, 
        "--Select Channel--", 
        new Dictionary<string, object> { { "id", "ChannelsDDL" } }
    )
    @Html.ValidationMessageFor(xModels => xModels.SelectedChannelID)    
