    public static IObservable<string> ReadLines(Stream stream)
    {
        return Observable.Using(
            () => new StreamReader(stream),
            reader => Observable.FromAsync(reader.ReadLineAsync)
                                .Repeat()
                                .TakeWhile(line => line != null));
    }
