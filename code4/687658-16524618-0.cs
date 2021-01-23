    foreach (TextBox item in Controls)
    {
        if (item.Name.Substring(0,7)=="txtders")
        {
            dersler[i] = Convert.ToString(item.Text);
            i++;
        }
    }
