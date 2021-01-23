        Double[] w = { 1000, 2000, 3000, 4000, 5000 }; // it has to be sorted
        double search = 3001;
        double lowerClosest = 0;
        double upperClosest = 0;
        
            for (int i = 1; i < w.Length; i++)
            {
                if (w[i] > search)
                {
                    upperClosest = w[i];
                    break; // interrupts your foreach
                }
            }
            for (int i = w.Length-1; i >=0; i--)
            {
                if (w[i] <= search)
                {
                    lowerClosest = w[i];
                    break; // interrupts your foreach
                }
            }
        Console.WriteLine(" lowerClosest:{0}", lowerClosest);
        Console.WriteLine(" upperClosest:{0}", upperClosest);
        if (upperClosest - search > search - lowerClosest)
            Console.WriteLine(" Closest:{0}", lowerClosest);
        else
            Console.WriteLine(" Closest:{0}", upperClosest);
        Console.ReadLine();
