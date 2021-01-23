        public int FirstDecreasingIndex(IList<int> myList)
        {
            for (int i = 0; i < myList.Count - 1; i++)
            {
                if (myList[i] > myList[i + 1])
                    return i+1;
            }
            return -1; //Or some other value
        }
