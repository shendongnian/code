	Dictionary<CheckBox, Func> checkboxes = new Dictionary<CheckBox, Func>();
	void Init()
	{
		checkboxes.Add(FooCheckBox, Foo);
		checkboxes.Add(BarCheckBox, Bar);
		checkboxes.Add(BazCheckBox, Baz);
	}
	
	void DoWork()
	{
		foreach (KeyValuePair<CheckBox, Func> checkbox in checkboxes)
		{
			if (checkbox.Key.Checked)
			{
				checkbox.Value();
				Console.WriteLine("{0} was called", checkbox.Text);
			}
		}
	}
