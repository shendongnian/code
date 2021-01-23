    ComboColumn.DataSource = Enum.GetValues(typeof(DoneStatus))
        .Cast<DoneStatus>()
        .Select(p => new { Key = (int)p, Value = p.ToString() })
        .ToList();
    // you can change the display member and value member
    // based on which value you have stored in database
    ComboColumn.DisplayMember = "Key";
    ComboColumn.ValueMember = "Value";
    ComboColumn.DataPropertyName = "MyStatus";
