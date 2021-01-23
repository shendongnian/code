    int TimesTwo(int arg) { return arg * 2; }
    int TimesThree(int arg) { return arg * 3; }
    IEnumerable<int> DoubleTheSequence(IEnumerable<int> input)
    {
        return input.Select(TimesTwo);
    }
    IEnumerable<int> TripleTheSequence(IEnumerable<int> input)
    {
        return input.Select(TimesThree);
    }
