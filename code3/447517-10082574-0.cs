    this.dateTimePicker1.CustomFormat = "hh:mm";
    this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
.......
    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
        MessageBox.Show(dateTimePicker1.Value.TimeOfDay.ToString());
    }
