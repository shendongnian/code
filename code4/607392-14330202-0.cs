    class Foo 
    {
            List<Bar> bar;
            List<int> SomeFunc()
            {
                return LoopedTest(b => b.IsSomething());
            }
            List<int> SomeOtherFunc()
            {
                return LoopedTest(b => b.IsSomethingElse());
            }
            private List<int> LoopedTest(Predicate<Bar> test)
            {
                List<int> list = new List<int>();
                for (int i = 0; i < bar.Count; i++)
                {
                    if (test(bar[i]))
                    {
                        list.Add(i);
                    }
                }
                return list;
            }
    }
