    public static IEnumerable<SelectListItem> ToSelectItemList<TSource, TKey>(
        this IEnumerable<TSource> enumerable,
        Func<TSource, TKey> text,
        Func<TSource, TKey> value)
    {
        List<SelectListItem> selectList = new List<SelectListItem>();
        foreach (TSource model in enumerable)
        {
            selectList.Add(new SelectListItem()
            {
                Text = text(model),
                Value = value(model)
            });
        }
        return selectList;
    }
