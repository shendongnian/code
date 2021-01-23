    internal class Program
    {
        private class Data
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public override string ToString()
            {
                return String.Format("My name is {0} and I'm living at {1}", Name, Address);
            }
        }
        static Expression<Func<Data,bool>> BuildExpression(PropertyInfo prop, IQueryable<string> restrict)
        {
            return (data) => !restrict.Any(elem => elem == prop.GetValue(data, null));
        }
        static IQueryable<Data> FilterData(IQueryable<Data> input, Expression<Func<Data, bool>> filter)
        {
            return input.Where(filter);
        }
        public static void Main (string[] args)
        {
            List<Data> list = new List<Data>()
                                   {
                                       new Data {Name = "John", Address = "1st Street"},
                                       new Data {Name = "Mary",Address = "2nd Street"},
                                       new Data {Name = "Carl", Address = "3rd Street"}
                                   };
            var filterByNameExpression = BuildExpression(typeof (Data).GetProperty("Name"),
                                                         (new List<string> {"John", "Carl"}).AsQueryable());
            var filterByAddressExpression = BuildExpression(typeof(Data).GetProperty("Address"),
                                                         (new List<string> { "2nd Street"}).AsQueryable());
            IQueryable<Data> filetedByName = FilterData(list.AsQueryable(), filterByNameExpression);
            IQueryable<Data> filetedByAddress = FilterData(list.AsQueryable(), filterByAddressExpression);
            Console.WriteLine("Filtered by name");
            foreach (var d in filetedByName)
            {
                Console.WriteLine(d);
            }
            Console.WriteLine("Filtered by address");
            foreach (var d in filetedByAddress)
            {
                Console.WriteLine(d);
            }
            Console.ReadLine();
        }
