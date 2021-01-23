	private static T GetAttribute<T>(Enum value)
	{
		T attribute = value.GetType()
			.GetMember(value.ToString())[0].GetCustomAttributes(typeof(T), false)
			.Cast<T>()
			.SingleOrDefault();
		return attribute;
	}
	DataGridViewComboBoxColumn CreateComboBoxWithEnums()
	{
		DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
		//combo.DataSource = Enum.GetValues(typeof(Title));        
		
		var datatable = new DataTable(); //Setup a DataTable for your ComboBox Column
		datatable.Columns.Add("col1", typeof(string));
		datatable.Columns.Add("col2", typeof(Title));
		foreach (Title item in Enum.GetValues(typeof(Title)))
			datatable.Rows.Add(GetAttribute<DescriptionAttribute>(item).Description, item);
		combo.DisplayMember = "col1";
		combo.ValueMember = "col2";
		combo.DataSource = datatable;
		combo.DropDownWidth = 200;
		combo.DataPropertyName = "Title";
		combo.Name = "Title";
		return combo;
	}
	private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
	{
		if (e.ColumnIndex == 0)//where Column1 is your combobox column
		{
			var val = dataGridView1[e.ColumnIndex, e.RowIndex].Value;
			if (val != null)
			{
				e.Value = ((Title)val).ToString();
				e.FormattingApplied = true;
			}
		}
	}
	
	public enum Title
    {
        [Description("This better be thy king!")]
        King,
        [Description("aka wanna-be-king")]
        Sir
    };
