    // mappings
    public class FooMap : ClassMap<Foo>
    {
        public FooMap()
        {
            Map(f => f.Name);
            HasMany(f => f.Bars).KeyColumn("foo_Id");
        {
    }
    
    public class BarMap : ClassMap<Bar>
    {
        public BarMap()
        {
            Map(f => f.Name);
        {
    }
    // query
    var john = session.Query<IFoo>()
        .Where(f => f.Name == "John")
        .Fetch(f => f.Bars)
        .Single();
    Console.Writeline(john.Bars.Count);
