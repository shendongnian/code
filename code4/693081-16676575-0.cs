    string[] splits = expr.ParentBinding.Path.Path.Split('.');
    Type type = expr.DataItem.GetType();
    foreach (string split in splits) {
        type = type.GetProperty(split).PropertyType;
    }
