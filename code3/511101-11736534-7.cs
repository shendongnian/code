        static void Main(string[] args)
        {
            var res = GetData()
                        .AsEnumerable()
                        .Select(d=>d.Field<string>("URL_Link"))
                        .Distinct();
            foreach (var item in res)
                Console.WriteLine(item.ToString());  
            Console.ReadLine();
        }
