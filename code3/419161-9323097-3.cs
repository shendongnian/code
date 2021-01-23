    YourClass
    {
	private List<object> list;
	public YourClass()
	{
		list = new List<object>();
		datagrid.datasource = list;
	}
	protected void OnClickButton(object sender, args e)
	{
		 list.add(new { Gender = genderComboBox.Text, Country = countryComoBox.Text });
		 datagrid.DataBind();
	}
    }
