     DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
     col.ValueType = typeof(MyEnum);
     col.ValueMember = "Value";
     col.DisplayMember = "Display";
     colElementtyp.DataSource = new MyEnum[] { MyEnum.Firstenumvalue, MyEnum.Secondenumvalue }
         .Select(value => new { Display = value.ToString(), Value = value })
         .ToList();
