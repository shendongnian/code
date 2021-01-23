    @model MyViewModel[]
    
    @Html.ValidationSummary()
    
    @using (Html.BeginForm())
    {
        @Html.HttpMethodOverride(HttpVerbs.Delete)
        for (int i = 0; i < Model.Length; i++)
        {
            <div>
                @Html.HiddenFor(m => m[i].Id)
                @Html.CheckBoxFor(m => m[i].Delete)
                @Model[i].Id
            </div>
        }
        <button type="submit">Delete</button>
    }
