    public static void MapTo<TObject>(this TObject source, TObject target, params Action<TObject, TObject>[] properties)
    {
        foreach (var property in properties)
        {
            property(source, target);
        }
    }
