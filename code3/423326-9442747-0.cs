    @using (Html.BeginForm())
    {
        @Html.LabelFor(xModels => xModels.SelectedChannelID)
        @Html.DropDownListFor(
            x => x.SelectedChannelID, 
            Model.ChannelSelectList, 
            "--Select Channel--", 
            new Dictionary<string, object> { { "id", "ChannelsDDL" } }
        )
        @Html.ValidationMessageFor(xModels => xModels.SelectedChannelID)    
        <button type="submit">OK</button>
    }
