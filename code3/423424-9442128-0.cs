    //get indexes of all '?'
    list<int> charlist = new list<int>();
    string buff = textbox.Text;
    for(int c = 0; c< buff.length, c++)
    {
        if (buff[c] == '?')
        {
            charlist.add(c)
        }
    }
    //inside keypress event
    foreach(int c in charlist)
    {
        if (textbox.Text[c] != '?')
        {
            textbox.Text = textbox.Text.Insert(c, "*");
        }
    }
