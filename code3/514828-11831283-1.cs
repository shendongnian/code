    int n;
    // TryParse method tries parsing and returns true on successful parsing
    if (int.TryParse(textBox2.Text, out n))
    {
        if (n > 0)
             // code for positive n
        else
             // code for negative n
    }
    else
         // handle parsing error
