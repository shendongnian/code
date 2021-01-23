    public static IQueriable<User> FilterByAge(this IQueriable<User> users, int inputAge)
    {
        return users
            .Where(x => x.Age == inputAge)
            .OrderByDescending(x => x.Created);
    }
