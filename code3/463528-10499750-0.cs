    @foreach(var itemList in Model.Items)
    {
        foreach(var item in itemList)
        {
            <div>
                @Html.RadioButtonFor(model => item.ItemId)
                @Html.LabelFor(model => item.Description)
            <div>
        }
    }
