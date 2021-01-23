    public static IEnumerable<ListPairing> PairUpLists(IEnumerable<int> sortedAList,
                                                       IEnumerable<int> sortedBList)
    {
        var aEnum = sortedAList.GetEnumerator();
        var bEnum = sortedBList.GetEnumerator();
        bool haveA = aEnum.MoveNext();
        bool haveB = bEnum.MoveNext();
        while (haveA && haveB)
        {
            int comparison = aEnum.Current.CompareTo(bEnum.Current);
            if (comparison < 0)
            {
                yield return new ListPairing() {ASide = aEnum.Current};
                haveA = aEnum.MoveNext();
            }
            else if (comparison == 0)
            {
                yield return new ListPairing() {
                        ASide = aEnum.Current,
                        BSide = bEnum.Current
                    };
                haveA = aEnum.MoveNext();
                haveB = bEnum.MoveNext();
            }
            else
            {
                yield return new ListPairing() {BSide = bEnum.Current};
                haveB = bEnum.MoveNext();
            }
        }
        if (haveA)
        {
            do
            {
                yield return new ListPairing() { ASide = aEnum.Current };
            } while (aEnum.MoveNext());
        }
        if (haveB)
        {
            do
            {
                yield return new ListPairing() { BSide = bEnum.Current };
            } while (bEnum.MoveNext());
        }
    }
