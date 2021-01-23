    foreach (var item in groupBox1.Controls)
    {
        if (item.GetType() == typeof(CheckBox))
        {
            ((CheckBox)item).Checked = true;
        }
    }
