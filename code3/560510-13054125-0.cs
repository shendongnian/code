This is because the DefaultValue only accepts constant values. You can do this via another approach some thing like below
	public int SelectedYear{
		get{
			return _selYear == 0 ? DateTime.Now.Year : _selYear;
		}
		set{
			_selYear = value;
			UpdateCalendar();
		}
	}
