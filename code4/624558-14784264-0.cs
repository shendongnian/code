    public class Type1
    {
        public string ID { get; set; }
        public Guid common { get; set; }
    }
    public class Type2
    {
        public string Value { get; set; }
        public Guid common { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Guid CommonGuid = Guid.NewGuid();
            IEnumerable<Type1> EnumType1 = new List<Type1>()
            {
                new Type1() {
                    ID = "first",
                    common = CommonGuid
                },
                new Type1() {
                    ID = "second",
                    common = CommonGuid
                },
                new Type1() {
                    ID = "third",
                    common = Guid.NewGuid()
                }
            } as IEnumerable<Type1>;
            IEnumerable<Type2> EnumType2 = new List<Type2>()
            {
                new Type2() {
                    Value = "value1",
                    common = CommonGuid
                },
                new Type2() {
                    Value = "value2",
                    common = Guid.NewGuid()
                },
                new Type2() {
                    Value = "value3",
                    common = CommonGuid
                }
            } as IEnumerable<Type2>;
            //--The part that matters
            EnumType1.Join(EnumType2, outer => outer.common, inner => inner.common, (inner, outer) => new { ID = inner.ID, Value = outer.Value })
                .ToList()
                .ForEach(item =>
                    {
                        Console.WriteLine("{0}: {1}", item.ID, item.Value);
                    });
            Console.ReadKey();
        }
    }
