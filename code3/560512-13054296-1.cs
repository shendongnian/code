    int _selYear = null;
    [AmbientValue(null)]
    [DefaultValue(null)]
    public int? SelectedYear{
        get{
            return _selYear ?? DateTime.Today.Year;
        }
        set{
            _selYear = value;
            UpdateCalendar();
        }
    }
