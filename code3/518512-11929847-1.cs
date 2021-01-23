    // C# to convert a byte array to a string.
    byte [] dBytes = ...
    string str;
    System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
    str = enc.GetString(dBytes);
