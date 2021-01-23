    public int SelectedYear{
        get{
            if (_selYear.Equals(0)){
                return  DateTime.Today.Year;
            }
            else{
                return _selYear;
            }
        }
        set{
            _selYear = value;
            UpdateCalendar();
        }
    }
