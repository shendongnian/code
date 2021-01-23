    public static bool PlatypusIsAFornightOrLessOld(int platypusId) {
        DateTime oneFortnightAgo = DateTime.Today.PlusDays(-14);
        ... SQL stuff ...
        return dt >= oneFortnightAgo;
    }
