    public static class MyExtensions {
        public static IQueryable<Participant> InDefaultOrder(this IQueryable<Participant> source) {
            return source.OrderBy(q => q.Person.Name).ThenBy(q => q.Person.FirstName);
        } 
    }
