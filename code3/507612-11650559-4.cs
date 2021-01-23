    using System;
    using System.Linq;
    
    class Program {
        static void Main(string[] args) {
            var input = Enumerable.Range(1, 10).Select(x => Tuple.Create(x, x*x));
    
            var res = input.Aggregate(new { Firsts = 0, Seconds = 0}, (total, val) => {
                return new {
                    Firsts = total.Firsts + val.Item1,
                    Seconds = total.Seconds + val.Item2
                };
            });
    
            Console.WriteLine("Firsts: {0}; Seconds: {1}", res.Firsts, res.Seconds);
        }
    }
