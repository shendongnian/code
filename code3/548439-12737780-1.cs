            int n = 0;
            int x = n++;
            int y = ++n;
            Console.WriteLine(string.Format("x={0}", x));
            Console.WriteLine(string.Format("y={0}", y));
            Console.WriteLine(x + y); //n++ + ++n == 0 + 2 == 2
            n = 0;
            x = ++n;
            y = n++;
            Console.WriteLine(string.Format("x={0}", x));
            Console.WriteLine(string.Format("y={0}", y));
            Console.WriteLine(x + y); //++n + n++ == 1 + 1 == 2
