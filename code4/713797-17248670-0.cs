          public void WriteData()
          {
               Console.SetCursorPosition(0, 4);
               for (int col = 0; col < 3; col++)
               {
                    for (int row = 0; row < 3; row++)
                    {
                        Console.Write("{0}\t", myNos[col, row]);
                    }
                    Console.WriteLine();
                }
                //This was the modification
                menu = "a";
         }
