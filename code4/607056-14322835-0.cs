    // Let's start with some character from the ancient Aegean numbers:
    // The code point of Aegean One is U+10107. Code points > U+FFFF need two
    // code units with two bytes each if you encode them in UTF-16 (Encoding.Unicode)
    string aegeanOne = char.ConvertFromUtf32(0x10107);
    byte[] aegeanOneBytes = Encoding.Unicode.GetBytes(aegeanOne);
    // Length == 4 (2 bytes each for high and low surrogate)
    // == 0, 216, 7, 221
    // Let's just take the first two bytes.
    // This creates a malformed byte sequence,
    // because the corresponding low surrogate is missing.
    byte[] a = new byte[2];
    a[0] = aegeanOneBytes[0]; // == 0
    a[1] = aegeanOneBytes[1]; // == 216
    string s = Encoding.Unicode.GetString(a);
    // == replacement character � (U+FFFD),
    // because the bytes could not be decoded properly (missing low surrogate)
    byte[] aa = Encoding.Unicode.GetBytes(s);
    // == 253, 255 == 0xFFFD != 0, 216
    string s2 = Encoding.Default.GetString(a);
    // == "\0Ø" (NUL + LATIN CAPITAL LETTER O WITH STROKE)
    // Results may differ, depending on the default encoding of the operating system
    byte[] aa2 = Encoding.Default.GetBytes(s2);
    // == 0, 216
