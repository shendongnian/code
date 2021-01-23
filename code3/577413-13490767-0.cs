    static class Program {
        static void Main()
        {
            Order o1 = new Order { Resenh = "abc" },
                  o2 = new Order { Resenh = "abc" };
            ShowDiffs(o1, o2); // {nothing}
            o2.Resenh = "def";
            ShowDiffs(o1, o2); // Resenh changed from abc to def
        }
        static void ShowDiffs<T>(T x, T y)
        {
            var accessor = TypeAccessor.Create(typeof(T));
            if (!accessor.GetMembersSupported) throw new NotSupportedException();
            var members = accessor.GetMembers();
    
            foreach (var member in members)
            {
                object xVal = accessor[x, member.Name],
                       yVal = accessor[y, member.Name];
                if (!Equals(xVal, yVal))
                {
                    Console.WriteLine("{0} changed from {1} to {2}",
                        member.Name, xVal, yVal);
                }
            }
        }
    }
