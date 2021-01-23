    public class FromClass
    {
        public List<Item> Foo { get; set; }
    }
    public class ToClass
    {
        public List<Item> Foo { get; set; }
    }
    public class Item
    {
        public string Bar { get; set; }
    }
    var list =  new List<Item> { new Item{ Bar = "a"}, new Item() { Bar= "b" }};
    FromClass anObject = new FromClass() { Foo = list };
    var queryableObjects = (new FromClass[] { anObject }).AsQueryable();
    Mapper.CreateMap<FromClass, ToClass>();
    Mapper.CreateMap<Item, Item>();
    var test2 = queryableObjects.Project().To<ToClass>().ToArray();
