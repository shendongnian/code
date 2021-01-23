    class Foo 
    {
            List<Bar> bar;
            List<int> SomeFunc()
            {
                return FindIndexes(b => b.IsSomething());
            }
            List<int> SomeOtherFunc()
            {
                return FindIndexes(b => b.IsSomethingElse());
            }
            private List<int> FindIndexes(Predicate<Bar> test)
            {
                return IEnumerable.Range(0, bar.Count).Where(i => test(bar[i])).ToList();
            }
    }
