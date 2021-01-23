    bool keepGoing = true;
    for (int col = 0; col < 8 && keepGoing; col++)
    {
        for (int row = 0; row < 8 && keepGoing; row++)
        {
            if (something)
            {
                 // Do whatever
                 keepGoing = false;
            }
        }
    }
