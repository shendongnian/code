    @for (int i=0; i < Model.Products.Count; i++)
    {
        @Html.Label(prod.Name)
        @Html.HiddenFor(model => model.Products[i].ID)
        @Html.CheckBoxFor(model => model.Products[i].IsSelected, new { name = prod.Name })
    }
