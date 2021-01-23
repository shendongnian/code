    @model MyMvcApplication.Models.MyModel
    @using (Html.BeginForm())
    {
        <div>
            @Html.LabelFor(m => m.Name)
            @Html.TextBoxFor(m => m.Name)
        </div>
    
        <div>
            @for (int i = 0; i < Model.Tags.Count; i++)
            {
                @Html.DisplayFor(x => Model.Tags[i].Name)
                @Html.EditorFor(x => Model.Tags[i].IsChecked)
            }
        </div>
        <input type="submit" value="Submit" />
    }
