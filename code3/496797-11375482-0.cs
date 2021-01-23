    public bool UseRowKey
    {
        get
        {
            return Content != null
                && !string.IsNullOrEmpty(Content.RowKey)
                && Content.RowKey
                .StartsWith("x", StringComparison.InvariantCultureIgnoreCase);
        }
    }
