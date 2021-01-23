    public class Table1Map
    {
       this.Id(x => x.Id);
       HasMany(x => x.Table2)
       .Not.KeyUpdate() <--here
       .Cascade.All();   
    }
