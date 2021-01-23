    class Program
    {
        static void Main(string[] args)
        {
            var A = new List<AA>();
            var B = new List<BB>();
            var C = new List<CC>();
            for (var a = 1; a < 4; a++)
            {
                A.Add(new AA { Id = a, aId = a });
                for (var b = 1; b < 4; b++)
                {
                    B.Add(new BB { Id = b, aId = a, bId = b });
                    for (var c = 1; c < 4; c++)
                        C.Add(new CC { Id = c, bId = b });
                }
            }
            var abc = from a in A
                      join b in B
                      on a.aId equals b.aId into Bees
                      from bs in Bees
                      join c in C 
                      on bs.bId equals c.bId into Cees
                      select new { a.Id, Bees, Cees };
            Console.WriteLine("A: {0}", A.Count());
            Console.WriteLine("B: {0}", B.Count());
            Console.WriteLine("C: {0}", C.Count());
            foreach (var x in abc)
            {
                var bees = x.Bees.Count();
                var cees = x.Cees.Count();
                var str = String.Format("Id: {0}, Bees: {1}, Cees: {2} ", x.Id, bees, cees);
                Console.WriteLine(str);
            }
         }
    }
