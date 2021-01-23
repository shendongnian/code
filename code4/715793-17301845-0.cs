    @for(int idx = 0;idx < Model.ListColors.Count;idx++)
    {
        var item = Model.ListColors[idx]
        @Html.Image(string.Format(
               "~\\Images\\Functional\\{0}Color.jpeg",
               item.Key.ToLower()), item.Key, null)
        @Html.CheckBoxFor(_ => Model.ListColors[idx].Value, item.Value)
    }
