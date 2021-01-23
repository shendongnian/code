    class Program
    {
        static void Main(string[] args)
        {
            var unit = new Unit();
            unit.OnChanged += Unit_OnChanged;
            Console.WriteLine("Before");
            Task.Factory.StartNew(unit.Process);
            Console.WriteLine("After");
    
            Console.WriteLine("Manual blocking, or else app dies");
            Console.ReadLine();
        }
    
        static void Unit_OnChanged(object sender, EventArgs e)
        {
            //Do your processing here
            Console.WriteLine("Unit_OnChanged before");
            Task.Factory.StartNew(()=>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Unit_OnChanged finished");
            });
            Console.WriteLine("Unit_OnChanged after");
        }
    }
