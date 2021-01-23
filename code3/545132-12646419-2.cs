    public static U Into<T, U>(this T self, Func<T, U> func)
    {
        return func(self);
    }
    
    var result = MyDC.TheTable
        .Where(x => ListOfRecordIDs.Contains(x.RecordID) && x.SomeByte < 7)
        .GroupBy(x => x.SomeByte)
        .ToDictionary(grp => grp.Key, grp => grp.Count())
        .Into(dict => new MyCountModel()
        {
            CountSomeByte1 = dict[1];
            CountSomeByte2 = dict[2];
            CountSomeByte3 = dict[3];
            CountSomeByte4 = dict[4];
            CountSomeByte5 = dict[5];
            CountSomeByte6 = dict[6];
        });
