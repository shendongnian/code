    public static class Enumerable
    {
        public static IEnumerable<Person> GetFirsts(this IEnumerable<Person> source)
        {
            var set = new HashSet<int>();
            foreach (var person in source)
            {
                if (person.parentId == 0 || set.Add(person.parentId))
                    yield return person;
            }
        }
    }
