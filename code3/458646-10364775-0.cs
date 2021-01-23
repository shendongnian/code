    if(!string.IsNullOrEmpty(textBox2.Text) && Heb[Line].Def.Contains(textBox2.Text))
    { 
        Success(); 
    }
    else
    {
        Fail();
    }
