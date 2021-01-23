    public static bool PlatypusIsAFornightOrLessOld(int platypusId) {
        DateTime oneFortnightAgo = DateTime.Today.AddDays(-14);
        ... SQL stuff ...
        return dt >= oneFortnightAgo;
    }
