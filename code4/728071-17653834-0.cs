    @foreach (var myListItem in Model.MyList)
    {
        if (Model.MyTypeId == myListItem.MyTypeId)
        {
            @Html.RadioButtonFor(m => m.MyType,myListItem.MyType,
                new
                {
                    id = myListItem.MyType,
                    @Checked = ""
                })
        }
        else
        {
            @Html.RadioButtonFor(m => m.MyType,myListItem.MyType,
                new
                {
                    id = myListItem.MyType,
                })
        }
        @myListItem.MyType
    }
