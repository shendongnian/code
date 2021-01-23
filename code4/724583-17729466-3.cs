    public static IEnumerable<object> ToKittenListViewModel(
        this IQueryable<Kitten> kittens, int minFluffiness, int pageItems)
    {
        return kittens
            .Where(kitten => kitten.fluffiness > minFluffiness)
            .OrderBy(kitten => kitten.name)
            .Select(kitten => new {
                Name = kitten.name,
                Url = kitten.imageUrl
            })
            .Take(pageItems)
            .AsEnumerable()
            .Cast<object>();
    }
