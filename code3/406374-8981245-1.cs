    // In control initialization somewhere
    dateTimePicker1.Tag = new DateTimePickerParams() { Series = myseries, Multiplier = multiplier }; // Where DateTimePickerParams is your own private class/struct defined explicitly for this purpose...
    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
        var ctl = sender as DateTimePicker;
        var parameters = ctl.Tag as DateTimePickerParams;
        var mySeries = parameters.Series;
        var multiplier = parameters.Multiplier;
        // Execute...
    }
