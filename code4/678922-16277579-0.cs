    class DataGridViewCalendarCell : DataGridViewTextBoxCell
    {
        (...)
        public string CustomFormat { get; set; }
        public DateTimePickerFormat Format { get; set; }
        public override object Clone()
        {
            var clone = (DataGridViewCalendarCell)base.Clone();
            clone.Format = Format;
            clone.CustomFormat = CustomFormat;
            return clone;
        }
    }
