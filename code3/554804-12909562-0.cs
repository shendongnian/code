    if (textbox.Text.Length <4)
    {
        return;
    }
    int i = 2;
    if textbox.Text.Length%2 ==0)
    {
        i = 1;
    }
    l = textbox.Text.Length;
    while(l > 3)
    {
        textbox.Text = textbox.Text.Insert(i, ",");
        i+=2;
        l-=2;
    }
    return;
