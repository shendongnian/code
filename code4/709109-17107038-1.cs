    foreach (KeyValuePair<string, string> Column in Columns)
    {
        GridViewColumn gvc = new GridViewColumn();
        Binding binding = new Binding(Column.Key);
        if (Column.Key == "Image")
        {
            binding.Converter = new MyImageConverter();
        }
        gvc.DisplayMemberBinding = binding;
        gv.Columns.Add(gvc);
    }
