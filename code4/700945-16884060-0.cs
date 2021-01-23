    int c = 0;
    for (int i = 0; i < myArray.Length; i++)
    {
        c = (myArray[i] == 1) ? c + 1 : 0;
        if (c == 10)
        {
            // do stuff
            c = 0; // reset
        }
    }
