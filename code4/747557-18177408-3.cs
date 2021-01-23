    using System;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        static class Program
        {
            static void Main()
            {
                var db = new DataContext("C:\\Databases\\test.mdf");
    
                var portfolio = db.GetTable<Portfolios>();
    
                var result =
                    from c in portfolio
                    where c.PORTF_CODE == "PTF1"
                    select c;
    
                foreach (var item in result)
                {
                    Console.WriteLine("id = {0}, City = {1}", item.PORTF_CODE, item.PORTF_NAME);
                }
    
                Console.ReadLine();
            }
        }
    
        [Table(Name = "PORTFOLIO")]
        public class Portfolios
        {
            [Column(IsPrimaryKey = true)]
            public int? PORTF_ID;
    
            [Column]
            public string PORTF_CODE;
    
            [Column]
            public string PORTF_NAME;
    
            [Column]
            public int? BENCH_ID;
    
            [Column]
            public int? CCY_ID;
        }
    }
