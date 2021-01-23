    void rdbtn1_Checked(object sender, RoutedEventArgs e)
    {
         textBox1.IsReadOnly = false;
         DatePicker1.Focusable = true;
         DatePicker1.IsHitVisible = true;
    }
    
    void rdbtn1_Unchecked(object sender, RoutedEventArgs e)
    {    
         textBox1.IsReadOnly = true;
         DatePicker1.Focusable = false;
         DatePicker1.IsHitVisible = false;    
    }
