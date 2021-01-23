    public String FormattedValue {
        get {
            return DatePickerInput.SelectedDate.HasValue
                ? DatePickerInput.SelectedDate.Value.ToString("dd/MM/yy")
                : ""; // return an empty string if SelectedDate is null
        }
    }
