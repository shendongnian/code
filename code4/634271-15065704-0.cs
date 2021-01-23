    private static SelectList ToSelectList(Type enumType, string selectedItem)
    {
        var items = new List<SelectListItem>();
        foreach (var item in Enum.GetValues(enumType))
        {
            var title = ((Enum)item).GetDescription();
            var listItem = new SelectListItem
            {
                Value = ((int)item).ToString(),
                Text = title,
                Selected = selectedItem == item.ToString()
            };
            items.Add(listItem);
        }
        return new SelectList(items, "Value", "Text");
    }
