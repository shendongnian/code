    int num = 48764;   // assign your number
    // Generate hexadecimal number in reverse.
    var sb = new StringBuilder();
    do
    {
        sb.Append(hexChars[num & 15]);
        num >>= 4;
    } 
    while (num > 0);
    // Pad with leading 0s for a minimum length of 4 characters.
    while (sb.Length < 4)
        sb.Append('0');
    // Reverse string and get result.
    char[] chars = new char[sb.Length];
    sb.CopyTo(0, chars, 0, sb.Length);
    Array.Reverse(chars);
    string result = new string(chars);
