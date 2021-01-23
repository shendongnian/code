    static void test(IEnumerable<int> myList)
    {
        int n = 0;
        foreach (int v1 in myList)
        {
            foreach (int v2 in myList.Skip(++n))
            {
                DoMyStuff(v1, v2);
            }
        }
    }
