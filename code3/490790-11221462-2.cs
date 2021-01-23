    public class BoyerMoore
    {
        public static int IndexOf(byte[] needle, byte[] haystack)
        {
            if (needle == null || needle.Length == 0)
                return -1;
            int[] charTable = CreateCharTable(needle);
            for (int i = needle.Length - 1, j; i < haystack.Length;)
            {
                for (j = needle.Length - 1; needle[j] == haystack[i]; i--, j--)
                {
                    if (j == 0)
                        return i;
                }
                i += charTable[haystack[i]];
            }
            return -1;
        }
        private static int[] CreateCharTable(byte[] needle)
        {
            const int ALPHABET_SIZE = 256;
            var table = new int[ALPHABET_SIZE];
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = needle.Length;
            }
            for (int i = 0; i < needle.Length - 1; i++)
            {
                table[needle[i]] = needle.Length - 1 - i;
            }
            return table;
        }
    }
