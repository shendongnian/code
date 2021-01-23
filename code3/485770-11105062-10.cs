    @model MyViewModel[]
    @Html.ValidationSummary()
    @using (Html.BeginForm())
    {
        @Html.HttpMethodOverride(HttpVerbs.Delete)
        for (int i = 0; i < Model.Length; i++)
        {
            <div>
                @Html.Hidden("index", Model[i].Id)
                @Html.Hidden("[" + Model[i].Id + "].Id", Model[i].Id)
                @Html.CheckBox("[" + Model[i].Id + "].Delete", Model[i].Delete)
                @Model[i].Id
            </div>
        }
        <button type="submit">Delete</button>
    }
