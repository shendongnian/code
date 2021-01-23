    @using (Html.BeginForm("SendItems", "ControllerName")
    { 
        for (int i = 0; i < Model.Items.Count; i++)
        {
            @* Have hidden fors to keep any other data in the class*@
            @HiddenFor(m => m.Items[i].Id)
            @Html.CheckBoxFor(model => model.Items[i].IsChecked)
        }
        <input type="submit" value="Save" />
    }
