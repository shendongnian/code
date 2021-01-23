    class Program {
        static void Main(string[] args) {
            List<Investment> list = new List<Investment>() { 
                new Investment { Return1Month = 8, Return2Month = 5 }, 
                new Investment { Return1Month = 2, Return2Month = 3 } 
            };
            
            var results = PerformanceSearch(list.AsQueryable(), x => x.Return1Month, 5, 10);
        }
    }
