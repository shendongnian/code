    Thickness t = new Thickness(0);
    if (value != null)
    { 
        t= new Thickness(System.Convert.ToInt64(((System.Windows.Controls.ComboBoxItem)value).GetValue(System.Windows.Controls.ComboBoxItem.ContentProperty)));
                  
    }
    return t;
