     DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
     col.ValueType = typeof(MyEnum);
     col.ValueMember = "Value";
     col.DisplayMember = "Display";
     colElementtyp.DataSource = Enum.GetValues(typeof(MyEnum)).OfType<MyEnum>().ToList() 
             .Select(value => new { Display = value.ToString(), Value = value })
             .ToList();
