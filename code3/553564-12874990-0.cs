    protected void MonthCalender1 _SelectionChanged(object sender, EventArgs e)
    {
        System.DateTime myDate = MonthCalender1 .SelectedDate;
        
        textBox1.Text = myDate.ToString ("dd/MM/yyyy"); 
    }
