            int totalNumber1Count = 0;
            int totalNumber2Count = 0;
            int totalNumber3Count = 0;
            int totalNumber4Count = 0;
            int testTotalCount = 100;
            foreach (var unused in Enumerable.Range(1, testTotalCount))
            {
                int selectedNumber = GetDistributedRandomNumber();
                Console.WriteLine($"selected number is {selectedNumber}");
                if (selectedNumber == 1)
                {
                    totalNumber1Count += 1;
                }
                if (selectedNumber == 2)
                {
                    totalNumber2Count += 1;
                }
                if (selectedNumber == 3)
                {
                    totalNumber3Count += 1;
                }
                if (selectedNumber == 4)
                {
                    totalNumber4Count += 1;
                }
            }
            Console.WriteLine("");
            Console.WriteLine($"number 1 -> total selected count is {totalNumber1Count} ({100 * (totalNumber1Count / (double) testTotalCount):0.0} %) ");
            Console.WriteLine($"number 2 -> total selected count is {totalNumber2Count} ({100 * (totalNumber2Count / (double) testTotalCount):0.0} %) ");
            Console.WriteLine($"number 3 -> total selected count is {totalNumber3Count} ({100 * (totalNumber3Count / (double) testTotalCount):0.0} %) ");
            Console.WriteLine($"number 4 -> total selected count is {totalNumber4Count} ({100 * (totalNumber4Count / (double) testTotalCount):0.0} %) ");
