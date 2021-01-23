    public enum Season
    {
       Unknown = 0,
       Spring,
       Summer,
       Autumn,
       Winter
    }
    Season some_season = Season.Unknown;
    int code = some_season.GetHashCode(); // 0
    some_season = Season.Autumn;
    code = some_season.GetHashCode(); // 3
