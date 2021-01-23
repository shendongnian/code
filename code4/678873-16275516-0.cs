    ComboColumn.DataSource = Enum.GetValues(typeof(DoneStatus))
        .Cast<DoneStatus>()
        .Select(p => new { Key = (int)p, Value = p.ToString() })
        .ToList();
    
    ComboColumn.DisplayMember = "Key";
    ComboColumn.ValueMember = "Value";
