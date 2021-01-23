    List<int> returnGreaterThanZero(int[] numbers)
        {
            List<int> greaterList = new List<int>();
            foreach (int oneNum in numbers)
            {
                if (oneNum > 0)
                    greaterList.Add(oneNum);
            }
            return greaterList;
            // return greaterList.ToArray(); // if you want to return int[] instead of List<int>
        }
