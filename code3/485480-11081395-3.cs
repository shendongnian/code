    public static IList<SelectListItem> ToSelectList<T>(this IQueryable<T> query
            , Expression<Func<T, long>> value
            , Expression<Func<T, string>> text
            , string nullText = null)
        {
            var result = (from x in
                              (from y in query.AsExpandable()
                               select new
                               {
                                   Value = value.Invoke(y),
                                   Text = text.Invoke(y),
                               }).AsEnumerable()
                          select new SelectListItem
                          {
                              Value = x.Value.ToString(),
                              Text = x.Text.ToString()
                          }).ToList();
            AddNullText(nullText, result);
            return result;
        }
    private static void AddNullText(string nullText, List<SelectListItem> result)
        {
            if (nullText != null)
            {
                result.Insert(0, new SelectListItem()
                {
                    Value = "",
                    Text = nullText,
                });
            }
        }
     
