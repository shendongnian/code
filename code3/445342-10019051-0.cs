    List<string> sortedResult = Perm("ABCDE",3);
---
    static int BitCount(int n)
    {
        int test = n,count = 0;
        while (test != 0)
        {
            if ((test & 1) == 1) count++;
            test >>= 1;
        }
        return count;
    }
    static List<string> Perm(string input,int M)
    {
        var chars = input.ToCharArray();
        int N = chars.Length;
        List<List<char>> result = new List<List<char>>();
        for (int i = 0; i < Math.Pow(2, N); i++)
        {
            if (BitCount(i) == M)
            {
                List<char> line = new List<char>();
                for (int j = 0; j < N; j++)
                {
                    if (((i >> j) & 1) == 1)
                    {
                        line.Add(chars[j]);
                    }
                }
                result.Add(line);
            }
        }
        return result.Select(l => String.Join("", l)).OrderBy(s => s).ToList();
    }
