    int count = 0;  
    int txtBoxVisible = 4;  
    foreach(Control c in Controls)
    {
        if(count <= txtBoxVisible)
        {
            TextBox tb = c as TextBox;
            if (tb !=null) tb.Visible = false; //or true, whatever.
            count++;
        }
    }
