    YourClass
    {
	private List<object> list;
	public Page_Load(object sender, args e)
	{
              if (!isPostBack) // only initialize once when the page first loads
              {
		          list = new List<object>();
		          datagrid.datasource = list;
              }
	}
	protected void OnClickButton(object sender, args e)
	{
		 list.add(new { Gender = genderComboBox.Text, Country = countryComoBox.Text });
		 datagrid.DataBind();
	}
    }
