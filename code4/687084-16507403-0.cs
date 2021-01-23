                if (userInput.Substring(i, 1) == S.Substring(i, 1))
                {
                    sB.Remove(i, 1);
                    sB.Insert(i, userInput.Substring(i, 1));
                    Console.WriteLine(sB);
                }
