    class TestComparer : IComparer<Test>
    {
        int Compare(Test a, Test b)
        {
            if (a.End < b.Start) return -1;
            else if (a.Start > b.End) return 1;
            else return 0;
        }
    }
    ...
    List.Sort(list, new TestComparer());
