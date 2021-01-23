    foreach (Control c in InformationsGroupControl.Controls)
    {
       if(c is TextEdit || c is DateEdit || c is ComboBoxEdit || c is MemoEdit || c is CheckEdit)
           (c as BaseEdit).Properties.ReadOnly = false;
    }
