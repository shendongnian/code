        static void Main(string[] args)
        {
            List<int> list1 = Split1(48, 15); // result is: 15, 15, 15, 3
            List<int> list2 = Split2(48, 15); // result is 12, 12, 12, 12
        }
        public static List<int> Split1 (int amount, int maxPerGroup)
        {
            int amountGroups = amount / maxPerGroup;
            if (amountGroups * maxPerGroup < amount)
            {
                amountGroups++;
            }
            List<int> result = new List<int>();
            for (int i = 0; i < amountGroups; i++)
            {
                result.Add(Math.Min(maxPerGroup, amount));
                amount -= Math.Min(maxPerGroup, amount);
            }
            return result;
        }
        public static List<int> Split2 (int amount, int maxPerGroup)
        {
            int amountGroups = amount / maxPerGroup;
            if (amountGroups * maxPerGroup < amount)
            {
                amountGroups++;
            }
            int groupsLeft = amountGroups;
            List<int> result = new List<int>();
            while (amount > 0)
            {
                int nextGroupValue = amount / groupsLeft;
                if (nextGroupValue * groupsLeft < amount)
                {
                    nextGroupValue++;
                }
                result.Add(nextGroupValue);
                groupsLeft--;
                amount -= nextGroupValue;
            }
            return result;
        }
