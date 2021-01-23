        static void Main()
        {
            Model m = new Model();
            // Set to IA
            IA asIA = m;
            asIA.Display();
            // Or use cast inline
            ((IB)m).Display();
            Console.ReadLine();
        }
