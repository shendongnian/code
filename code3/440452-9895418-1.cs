    string input = "ABCD 13 ~";
    // at worst, all characters are alphabetical, so we have to accommodate for that
    char[] output = new char[input.Length];
    int numberOfAlphabeticals = 0;
    for (int i = 0; i < input.Length; i++)
    {
        char character = input[i];
        var charCode = (byte) character;
        // based on ASCII 
        if ((charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122))
        {
            output[numberOfAlphabeticals ] = character;
            ++numberOfAlphabeticals ;
        }
    }
    string outputAsString = new string(output, 0, numberOfAlphabeticals );
