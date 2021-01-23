    public static class Funk<T>
    {
        public static Func<T, R> Make<R>(Func<T, R> func)
        {
            return func;
        }
    }
    ...
    var selector = Funk<SomeTableName>.Make(x => new {x.ID, x.Name});
    var result = db.SomeTable.Where(x => x.ID>1).Select(selector);
