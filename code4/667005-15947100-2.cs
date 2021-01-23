    class Foo
    {
        public string A { get; set; }
        public int B { get; set; }
        public DateTime C { get; set; }
    }
    class FooDto
    {
        public string A { get; set; }
        public int B { get; set; }
        public DateTime C { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var data = new[] { new Foo { A = "a", B = 1, C = DateTime.Now}}
                     .AsQueryable();
            var mapped = PartialMap<Foo, FooDto>(data, "A", "C").ToList();
        }
        static IQueryable<TTo> PartialMap<TFrom, TTo>(
            IQueryable<TFrom> source, params string[] members)
        {
            var p = Expression.Parameter(typeof(TFrom));
            var body = Expression.MemberInit(Expression.New(typeof(TTo)),
                from member in members
                select (MemberBinding)Expression.Bind(
                    typeof(TTo).GetMember(member).Single(),
                    Expression.PropertyOrField(p, member))
                );
            return source.Select(Expression.Lambda<Func<TFrom, TTo>>(body, p));
        }
    }
