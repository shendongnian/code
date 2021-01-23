    foreach (Control ctrl in Controls)
    {
        TextBox item = ctrl as TextBox;
        if (item != null) 
        {
            if (item.Name.Substring(0,7)=="txtders")
            {
                dersler[i] = Convert.ToString(item.Text);
                i++;
            }
        }
    }
