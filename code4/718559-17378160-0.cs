    TimeSpan difftime = DateTimePicker1.Subtract ( now() );
    if (difftime.Minutes > 15)
    {
        MessageBox.Show("Max 15 Minutes !"); 
    }
    
