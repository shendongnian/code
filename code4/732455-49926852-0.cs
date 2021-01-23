    public static bool IsVowelLinq(char c)
    {
    	char[] vowels = new[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        return vowels.Any(ch => ch == c);
    }
    
    private static int VowelMask = (1 << 1) | (1 << 5) | (1 << 9) | (1 << 15) | (1 << 21);
    
    public static bool IsVowelBitArithmetic(char c)
    {
    	// The OR with 0x20 lowercases the letters
    	// The test c > 64 rules out punctuation, digits, and control characters.
    	// An additional test would be required to eliminate characters above ASCII 127.
    	return (c > 64) && ((VowelMask & ((c | 0x20) % 32)) != 0);
    }
