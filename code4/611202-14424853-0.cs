     List<double> m = new List<double>();
       m.Add(1);
       m.Add(1.5);
       m.Add(2.6);
       m.Add(4);
       m.Add(50);
    
       m.Sort();
                
       int[] numbers = { 1, 2, 3, 5 };
       foreach (var item in numbers)
       {
            double min = m.Where(x => x <= item).Last();
            double max = m.Where(x => x > item).First();
    
            Console.WriteLine("find {0} range is {1} to {2}", item, min, max);
       }
