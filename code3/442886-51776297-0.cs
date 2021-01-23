    using System;
    using System.Linq;
        // ...
        private static readonly Random RandomGenerator = new Random();
        private int GetDistributedRandomNumber()
        {
            double totalCount = 208;
            var number1Pct = 150 / totalCount;
            var number2Pct = (150 + 40) / totalCount;
            var number3Pct = (150 + 40 + 15) / totalCount;
            var randomNumber = RandomGenerator.NextDouble();
            int selectedNumber;
            if (randomNumber < number1Pct)
            {
                selectedNumber = 1;
            }
            else if (randomNumber >= number1Pct && randomNumber < number2Pct)
            {
                selectedNumber = 2;
            }
            else if (randomNumber >= number2Pct && randomNumber < number3Pct)
            {
                selectedNumber = 3;
            }
            else
            {
                selectedNumber = 4;
            }
            return selectedNumber;
        }
