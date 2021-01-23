    class Program
    {
        static void Main(string[] args)
        {    
            List<Points> pointsOfList =  new List<Points>(){
                new Points() { x = 9, y = 3},
                new Points() { x = 4, y = 2},
                new Points() { x = 1, y = 1}
            };
    
            foreach (var points in pointsOfList.OrderBy(p => p.x))
            {
                Console.WriteLine(points.ToString());
            }
    
            Console.ReadKey();
        }
    }
    
    class Points
    {
        public int x { get; set; }
        public int y { get; set; }
    
        public override string ToString()
        {
            return string.Format("({0}, {1})", x, y);
        }
    }
