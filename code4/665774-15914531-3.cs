    public static IEnumerable<ListPairing> PairUpLists(IEnumerable<int> sortedAList,
                                                       IEnumerable<int> sortedBList)
    {
        // Should wrap these two in using() per Servy's comment with braces around
        // the rest of the method.
        var aEnum = sortedAList.GetEnumerator();
        var bEnum = sortedBList.GetEnumerator();
        bool haveA = aEnum.MoveNext();
        bool haveB = bEnum.MoveNext();
        while (haveA && haveB)
        {
            // We still have values left on both lists.
            int comparison = aEnum.Current.CompareTo(bEnum.Current);
            if (comparison < 0)
            {
                // The heads of the two remaining sequences do not match and A's is
                // lower. Generate a partial pair with the head of A and advance the
                // enumerator.
                yield return new ListPairing() {ASide = aEnum.Current};
                haveA = aEnum.MoveNext();
            }
            else if (comparison == 0)
            {
                // The heads of the two sequences match. Generate a pair.
                yield return new ListPairing() {
                        ASide = aEnum.Current,
                        BSide = bEnum.Current
                    };
                // Advance both enumerators
                haveA = aEnum.MoveNext();
                haveB = bEnum.MoveNext();
            }
            else
            {
                // No match and B is the lowest. Generate a partial pair with B.
                yield return new ListPairing() {BSide = bEnum.Current};
                // and advance the enumerator
                haveB = bEnum.MoveNext();
            }
        }
        if (haveA)
        {
            // We still have elements on list A but list B is exhausted.
            do
            {
                // Generate a partial pair for all remaining A elements.
                yield return new ListPairing() { ASide = aEnum.Current };
            } while (aEnum.MoveNext());
        }
        else if (haveB)
        {
            // List A is exhausted but we still have elements on list B.
            do
            {
                // Generate a partial pair for all remaining B elements.
                yield return new ListPairing() { BSide = bEnum.Current };
            } while (bEnum.MoveNext());
        }
    }
