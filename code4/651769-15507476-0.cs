            StreamReader fileContent = File.OpenText(@"C:\my-file.txt");
            
            Console.SetCursorPosition(15, 2);
            Console.Write("--- Names Table ---");
            Console.SetCursorPosition(10, 4);
            Console.Write("First Name");
            Console.SetCursorPosition(28, 4);
            Console.Write("Surname");
            int topOffset = 6;
            
            string currentLine = fileContent.ReadLine();
            while (!string.IsNullOrWhiteSpace(currentLine))
            {
                string firstName = currentLine.Split(' ')[0];
                string lastName = currentLine.Split(' ')[1];
                Console.SetCursorPosition(10, topOffset);
                Console.Write(firstName);
                Console.SetCursorPosition(28, topOffset);
                Console.Write(lastName);
                topOffset += 2;
                currentLine = fileContent.ReadLine();
            }
            fileContent.Dispose();
            Console.ReadLine();
