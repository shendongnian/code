    class Program
    {
        static void Main(string[] args)
        {
    
            GameItem g = new GameItem() { AnimatedField = 1 };
    
            Animation a = new Animation() { Item = g };
    
            a.Update();
    
            Console.WriteLine(g.AnimatedField);
    
            a.Update();
    
            Console.WriteLine(g.AnimatedField);
    
            a.Update();
    
            Console.WriteLine(g.AnimatedField);
    
            Console.ReadLine();
        }
    }
