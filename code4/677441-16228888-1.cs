    foreach (Control item in panel1.Controls)
    {
      if (item is TextBox || item is RadioButton || item is DateTimePicker)
      {
        item.Text = "Initial Value";
       }
    }
