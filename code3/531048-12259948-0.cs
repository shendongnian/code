    // DateTime TimeCheck = v.Besetzt_Von; <-- you don't need this
    if (DateTime.Now > v.Besetzt_Von.AddMinutes(30))
    {
        // ...
    }
