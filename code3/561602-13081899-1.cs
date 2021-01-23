	private void CheckBox_Checked(object sender, RoutedEventArgs e)
	{
		foreach (var item in MyDataGridSourceList)
		{
			item.MyBooleanProperty = true;
		}
	}
	private void UncheckBox_Checked(object sender, RoutedEventArgs e)
	{
		foreach (var item in MyDataGridSourceList)
		{
			item.MyBooleanProperty = false;
		}
	}
