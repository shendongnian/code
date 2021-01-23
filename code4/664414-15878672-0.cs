    public static class MyListExtensions {
        public static PersonCollection ToPersonCollection(this IEnumerable<Person> list) {
            return new PersonCollection(list.ToList());
        }
    }
