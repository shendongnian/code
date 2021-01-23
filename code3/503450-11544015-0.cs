	public static readonly DependencyProperty IsCheckboxCheckedProperty = DependencyProperty.Register("IsCheckboxChecked", typeof(bool), typeof(MyComboBox));
	public bool IsCheckboxChecked
	{
		get { return (bool)GetValue(IsCheckboxCheckedProperty); }
		set { SetValue(IsCheckboxCheckedProperty, value); }
	}
