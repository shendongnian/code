    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Address Address { get; set; }
        public int? AddressId {get; set;}
    }
...
    using (var ctx = new EFContext())
    {
        Person p = ctx.People.First();
        p.AddressId = null;
        var entry = ctx.Entry(p);
    }
