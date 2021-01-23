    foreach (String s in strings)
    { 
        String[] split = s.Split(new Char [] { '_' });
        
        if (split[0].Equals("CAT")
            cats.Add(s);
        else if (split[0].Equals("HORSE")
            horses.Add(s);
        // ...
    }
