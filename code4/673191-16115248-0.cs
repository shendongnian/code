    static int SimpleBoyerMooreSearch(byte[] haystack, byte[] needle)
    {
        int[] lookup = new int[256];
        for (int i = 0; i < lookup.Length; i++) { lookup[i] = needle.Length; }
   
        for (int i = 0; i < needle.Length; i++)
        {
            lookup[needle[i]] = needle.Length - i - 1;
        }
        int index = needle.Length - 1;
        var lastByte = needle.Last();
        while (index < haystack.Length)
        {
            var checkByte = haystack[index];
            if (haystack[index] == lastByte)
            {
                bool found = true;
                for (int j = needle.Length - 2; j >= 0; j--)
                {
                    if (haystack[index - needle.Length + j + 1] != needle[j])
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                    return index - needle.Length + 1;
                else
                    index++;
            }
            else
            {
                index += lookup[checkByte];
            }
        }
        return -1;
    }
