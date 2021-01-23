    public static System.Collections.IEnumerable GetStrings(inputString)
    {
        foreach(string s in inputString.Split('c'))
        {
            yield return s.Reverse();
            Thread.Sleep(1000);
        }
    }
