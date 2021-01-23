    int[] outcomes = new int[6];
    // init
    for (int i = 0; i < outcomes.Length; ++i) {
        outcomes[i] = 0;
    }
    for (int i = 0; i < rollDice; i++)
    {
        int diceRoll = 0;
        diceRoll = rndGen.Next(1,7);
        outcomes[diceRoll - 1]++; //increment frequency. 
        // Note that as arrays are zero-based, the " - 1" part turns the output range 
        // from 1-6 to 0-5, fitting into the array.
    }//end for
    // print the outcome values, as a table
