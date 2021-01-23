    @for(int idx = 0;idx < Model.ListColors.Count;idx++)
    {
        var item = Model.ListColors[idx]
        @Html.Image(string.Format(
               "~\\Images\\Functional\\{0}Color.jpeg",
               item.Name.ToLower()), item.Name, null)
        @Html.CheckBoxFor(model => Model[idx].IsSelected, item.IsSelected)
        @Html.HiddenFor(model => Model[idk].Name)
    }
