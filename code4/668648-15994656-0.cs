    DateTime? start = DateTimePicker1.Value;
    DateTime? end = DateTimePicker2.Value;
    DateTime now = DateTime.Now;
    if (start == null || end == null)
    {
        // one of the pickers is empty
    }
    else if (now >= start.Value && now <= end.Value)
    {
        // you selected values in range of "now"
    }
