        while (PressKey.Key == ConsoleKey.I)
        {
            Console.Clear();
            Console.WriteLine("{0}", classData.Information());
            PressKey =Console.ReadKey();
        }
