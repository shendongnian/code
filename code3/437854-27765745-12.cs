    protected void RefreshDataBindings()
	{
		foreach (Control control in this.Controls)
			RefreshControlBindingsRecursive(control);
	}
	private void RefreshControlBindingsRecursive(Control control)
	{
		if (!control.Visible || !control.Created)
		{
			foreach (Binding db in control.DataBindings)
			{
				if (db.PropertyName == "Visible")
				{
					try
					{
						object dataSource = db.DataSource is BindingSource ?
							(db.DataSource as BindingSource).DataSource : db.DataSource;
						PropertyInfo pi =
								dataSource.GetType().GetProperty(db.BindingMemberInfo.BindingMember); ;
						
						PropertyInfo piC = db.Control.GetType().GetProperty(db.PropertyName);
						piC.SetValue(db.Control, pi.GetValue(dataSource));
					}
					catch (Exception ex)
					{
						string s = ""; // not bothered its too late at night
					}
				}
			}
		}
		foreach (Control child in control.Controls)
			RefreshControlBindingsRecursive(child);
	}
 
