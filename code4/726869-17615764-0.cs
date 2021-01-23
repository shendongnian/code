    <ul id="categories>
        @for (int i = 0; i < Model.Categories.Count; i++)
        {
            @Html.EditorFor(model => Model.Categories[i]);
        }
    </ul>
