            [TestMethod]
            public void test()
            {
                var text = new String[6, 4]
                                   {
                                       {"A", "B", "C", "Yes"},
                                       {"A", "B", "C", "Yes"},
                                       {"A", "B", "C", "Yes"},
                                       {"A", "B", "C", "Yes"},
                                       {"A", "B", "Not", "C"},
                                       {"A", "B", "C", "Yes"}
                                   };
                var rowWithNot = new List<int>();
    
                for (int row = 0; row < 6; row++)
                    for (int col = 0; col < 4; col++)
                        if (text[row, col].Contains("Not"))
                        {
                            rowWithNot.Add(row);
                            break;
                        }
    
                foreach (var row in rowWithNot)
                {
                    for (int col = 0; col < 4; col++)
                    {
                        Console.WriteLine(text[row, col]);
                    }
    
                }
             }
