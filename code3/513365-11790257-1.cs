        string[] lines = File.ReadAllLines("d:\\TEST.txt");
        foreach (var line in lines.Where(line => line.Length > 0))
        {
            string[] rows = line.Split(',');
            double a = Convert.ToDouble(rows[1]);
            Console.Write(a);
            int b = Convert.ToInt32(rows[3]);
            Console.Write(b);
            Console.WriteLine();
        }
