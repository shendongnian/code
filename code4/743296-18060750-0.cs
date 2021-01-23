    Array result = someList.Select(t => new SelectListItem
                   {
                       Text = t.Text,
                       Value = TransformMyValue(t)
                   }).ToArray();
    private static String TransformMyValue(String value)
    {
        return value;
    }
