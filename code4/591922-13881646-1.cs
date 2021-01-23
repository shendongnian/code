    foreach(var item in panel1.Controls)
    {
    
        if(item is TextBox || item is ComboBox)
        {
              panel1.Controls.Remove(item);
        }
       
    
    }
