    void OutputSets(List<CustomSet> aSet, int setIndex, string hirarchyString)
    {
        string ouputString = hirarchyString;
        int nextIndex = setIndex + 1;
        foreach (string element in aSet[setIndex].Elements)
        {
            if (nextIndex < aSet.Count)
            {
                OutputSets(aSet, nextIndex, hirarchyString + element + " / ");
            }
            else
            {
                Console.WriteLine(ouputString + element + " / ");
            }
        }
    }
