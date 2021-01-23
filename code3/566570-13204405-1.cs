    firstIteration = false; 
    ....
    for (...)
    {
        if (firstIteration)
        {
            NextMove = playerPositions[i] + DiceThrow();
            firstIteration = !firstIteration; // Toggle the flag 
        }
    }
