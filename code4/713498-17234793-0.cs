    @model IList<Settings>
    @using (Html.BeginForm())
    {
        @for(int i=0; i<Model.Count; i++)
        {
           @Html.CheckBoxFor(m => m[i].IsActive, new { @value = Model[i].Id })
           @Html.DisplayFor(m => m[i].Name)
        }
        <input type="submit" value="Save" />
    }
