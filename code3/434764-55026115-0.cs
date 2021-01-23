            if (dbModelStrPathname == @"con" ||
                dbModelStrPathname == @"con:")
            {
                var stdin = Console.In;
                var inputBuffer = new byte[262144];
                var inputStream = Console.OpenStandardInput(inputBuffer.Length);
                Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));
                dbModelStr = Console.In.ReadLine();
                Console.SetIn(stdin);
            }
            else
            {
                dbModelStr = File.ReadAllText(dbModelStrPathname);
            }
