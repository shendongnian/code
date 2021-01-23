    public static class ComboExtensions
        {
            public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> enumerable,
                                                                          Func<T, string> text,
                                                                          Func<T, int> value)
            {
                return enumerable.Select(item => new SelectListItem
                                                     {
                                                         Text = text(item).ToString(),
                                                         Value = value(item).ToString(),
                                                     }).AsEnumerable();
            }
    
            public static IEnumerable<SelectListItem> WithDefaultValue(this IEnumerable<SelectListItem> selectListItems, int defaultValue = 0, string chooseText = "choose")
            {
                IList<SelectListItem> items = selectListItems.ToList();
                items.Insert(0, new SelectListItem {Value = defaultValue.ToString(), Text = chooseText});
    
