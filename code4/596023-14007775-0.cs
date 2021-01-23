    PropertyInfo property = GetType().GetProperty("Style");
    CssStyleCollection styles = property.GetValue(this, null) as CssStyleCollection;
    foreach (string key in styles.Keys)
    {
        styles[key] = ?
    }
