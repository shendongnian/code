    public class Test
    {
        public void Test()
        {
            AutoMapper.Mapper.CreateMap<FirstObject, SecondObject>();
            FirstObject t = new FirstObject();
            t.Items = new object[] { new Item() { Id = 1 }, new Item() { Id = 2 } };
            SecondObject result = AutoMapper.Mapper.Map<SecondObject>(t);
        }
    }
    public class FirstObject
    {
        public object[] Items { get; set; }
    }
    public class SecondObject
    {
        public object[] Items { get; set; }
    }
    public class Item
    {
        public int Id { get; set; }
    }
