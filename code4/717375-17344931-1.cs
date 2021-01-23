    static void imperfectMatch(String original, String testCase, int tolerance)
    {
        int mistakes = 0;
        if (original.Length == testCase.Length)
        {
            using (CharEnumerator enumerator1 = original.GetEnumerator())
            using (CharEnumerator enumerator2 = testCase.GetEnumerator())
            {
                while (enumerator1.MoveNext() && enumerator2.MoveNext())
                {
                    if (mistakes >= tolerance)
                        break;
                    if (enumerator1.Current != enumerator2.Current)
                        mistakes++;
                }
            }
        }
        else
            mistakes = -1;
        Console.WriteLine(String.Format("Original String: {0}", original));
        Console.WriteLine(String.Format("Test Case String: {0}", testCase));
        Console.WriteLine(String.Format("Number of errors: {0}", mistakes));
        Console.WriteLine();
    }
