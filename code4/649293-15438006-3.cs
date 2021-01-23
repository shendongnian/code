    class Program
    {
        static void Main(string[] args)
        {
            var A = new List<AA>();
            var B = new List<BB>();
            var C = new List<CC>();
            var abc = from a in A
              join b in B 
              on a.aId equals b.aId into Bees
              select new 
              {
                  Id = a.Id, 
                  Bees, 
                  Cees = from bs in Bees 
                  join c in C 
                  on bs.bId equals c.bId into Cees 
                  select Cees
              };
         }
    }
