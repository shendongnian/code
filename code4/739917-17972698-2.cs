     System.Array enumarray = Enum.GetValues(typeof(MyEnum));
     List<MyEnum> lst = enumarray.OfType<MyEnum>().ToList();
     DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
         col.ValueType = typeof(MyEnum);
         col.ValueMember = "Value";
         col.DisplayMember = "Display";
         colElementtyp.DataSource = lst 
             .Select(value => new { Display = value.ToString(), Value = value })
             .ToList();
