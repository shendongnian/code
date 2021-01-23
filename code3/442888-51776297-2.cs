    using System;
    using System.Linq;
        // ...
        private static readonly Random RandomGenerator = new Random();
        private int GetDistributedRandomNumber()
        {
            double totalCount = 208;
            var number1Prob = 150 / totalCount;
            var number2Prob = (150 + 40) / totalCount;
            var number3Prob = (150 + 40 + 15) / totalCount;
            var randomNumber = RandomGenerator.NextDouble();
            int selectedNumber;
            if (randomNumber < number1Prob)
            {
                selectedNumber = 1;
            }
            else if (randomNumber >= number1Prob && randomNumber < number2Prob)
            {
                selectedNumber = 2;
            }
            else if (randomNumber >= number2Prob && randomNumber < number3Prob)
            {
                selectedNumber = 3;
            }
            else
            {
                selectedNumber = 4;
            }
            return selectedNumber;
        }
