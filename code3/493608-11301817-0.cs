    ArrayList keys  = new ArrayList(Enum.GetValues(typeof(Keys)));
    Keys randomKey = (Keys)keys[new Random().Next(keys.Count)];
    
    if (ks.IsKeyDown(randomKey))
    {
        rightButton();
    }
    else { wrongButton(); }
