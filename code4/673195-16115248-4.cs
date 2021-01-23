     static int SimpleBoyerMooreSearch(IList<byte> haystack, IList<byte> needle)
     {
        int[] lookup = new int[256];
        for (int i = 0; i < lookup.Length; i++) { lookup[i] = needle.Count; }
        for (int i = 0; i < needle.Count; i++)
        {
            lookup[needle[i]] = needle.Count - i - 1;
        }
        int index = needle.Count - 1;
        var lastByte = needle[index];
        while (index < haystack.Count)
        {
            var checkByte = haystack[index];
            if (haystack[index] == lastByte)
            {
                bool found = true;
                for (int j = needle.Count - 2; j >= 0; j--)
                {
                    if (haystack[index - needle.Count + j + 1] != needle[j])
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                    return index - needle.Count + 1;
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
