            for (int dots = 0; dots <= 3; ++dots)
            {
                Console.Write("\rHello world{0}", new string('.', dots));
                System.Threading.Thread.Sleep(500); // half a sec
            }
            Console.WriteLine("\nAll done.");
