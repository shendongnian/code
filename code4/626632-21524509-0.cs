    private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
	{
		PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
		e.Column.Header = propertyDescriptor.DisplayName;
		if (propertyDescriptor.DisplayName == "IsInDesignMode")
		{
			e.Cancel = true;
		}
	}
