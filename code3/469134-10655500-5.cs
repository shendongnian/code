    DateTime d2;
    if(Regex.IsMatch(textBox9.Text, "^dddd/dd/dd$"))
    {
        d2 = new DateTime(
            int.Parse(textBox9.Substring(0,4)), 
            int.Parse(textBox9.Substring(5, 2)), 
            int.Parse(textBox9.Substring(8, 2)),
            p);
    }
