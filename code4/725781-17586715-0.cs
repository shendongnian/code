        private List<int> MatchList()
        {
            List<int[]> list1 = new List<int[]>() { new int[4] { 1, 2, 3, 4 }, new int[4] { 1, 2, 3, 5 } };
            List<int[]> list2 = new List<int[]>() { new int[2] { 1, 2 }, new int[2] { 3, 4 }, new int[2] { 3, 5 } };
            List<int> resultList = new List<int>();
            for (int i = 0; i < list1.Count; i++)
            {
                for (int j = 0; j < list2.Count; j++)
                {
                    if (i == j)
                    {
                        int result = 0;
                        foreach (int list1Element in list1[i])
                        {
                            foreach (int list2Element in list2[j])
                            {
                                if (list1Element == list2Element)
                                {
                                    result +=1;
                                }
                            }
                        }
                        resultList.Add(result);
                    }
                }
            }
            return resultList;
        }
