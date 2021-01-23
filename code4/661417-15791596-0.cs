    char c = 'X';
    int code = c - 'A'; // Bring the character code into the range 0-25
    code = code + rnd.Next(26); // encrypt
    code = code % 26; // roll over for codes > 25
    c = (char)('A' + code); // convert code to character
