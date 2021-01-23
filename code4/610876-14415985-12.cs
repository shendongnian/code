    SomeMethod(data);
    public void SomeMethod(IEnumerable<object> enumerable)
    {
        var template = new { F = new List<string>(), T = string.Empty };
        foreach (var item in enumerable)
        {
            var anonymousType = item.CastToTypeOf(template);
            //print string.Join(", ", anonymousType.F) + " - " + anonymousType.T //compiles
            //or whatever
        }
    }
    //a more generic name perhaps is 'CastToTypeOf' as an extension method
    public static T CastToTypeOf<T>(this object source, T example) where T : class
    {
        return (T)source;
    }
