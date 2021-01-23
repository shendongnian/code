    var decider = new Random();
    var largeRng = new Random();
    var smallRng = new Random();
    
    var deciderValue = decider.Next(1, 100);
    int generatedValue;
    
    if (deciderValue == 1) // will happen with probability 1/100
    {
        generatedValue = largeRng.Next(6, 12);
    }
    else
    {
        generatedValue = smallRng.Next(1, 5);
    }
