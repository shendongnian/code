    public async double DoItInOneHour(){
        return await Observable
                .Interval(TimeSpan.FromHours(1))
                .Take(1)
                .Select( i=> SomeFunction());
    }
