    class Program
        {
            static void Main(string[] args)
            {
                List<myobject> list = new List<myobject>();
    
                list.Add(new myobject { name = "n1", recordNumber = 1 });
                list.Add(new myobject { name = "n2", recordNumber = 2 });
                list.Add(new myobject { name = "n3", recordNumber = 3 });
                list.Add(new myobject { name = "n4", recordNumber = 3 });
    
                //Generates Row Number on the fly
                var withRowNumbers = list 
                        .Select((x, index) => new 
                                {
                                    Name = x.name,
                                    RecordNumber = x.recordNumber,
                                    RowNumber = index + 1
                                }).ToList();
                     
                //Generates Row Number with Partition by clause
                var withRowNumbersPartitionBy = withRowNumbers
                        .OrderBy(x => x.RowNumber)
                        .GroupBy(x => x.RecordNumber)
                        .Select(g => new { g, count = g.Count() })
                        .SelectMany(t => t.g.Select(b => b)
                        .Zip(Enumerable.Range(1, t.count), (j, i) => new { Rn = i, j.RecordNumber, j.Name}))
                        .Where(i=>i.Rn == 1)
                        .ToList();
                //print the result
                withRowNumbersPartitionBy.ToList().ForEach(i => Console.WriteLine("Name =  {0}   RecordNumber = {1}", i.Name, i.RecordNumber));
               
                Console.ReadKey();
            }
        }
    
        class myobject
        {
            public int recordNumber { get; set; }
            public string name { get; set; }
        }
