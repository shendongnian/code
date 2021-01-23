    public static IEnumerable<int> SplitIndexes(string subject, char search)
    {
        for(var i = 1; i < subject.Length; i++)
        {
            if(subject[i] == search)
            {
                yield return i;
            }
        }
        
        yield return subject.Length;
    }
