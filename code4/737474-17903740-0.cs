        private class ArrayComparer : IEqualityComparer<string[]>
        {
            public bool Equals(string[] item1, string[] item2)
            {
                if (item1[0] == item2[0])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public int GetHashCode(string[] item)
            {
                return item[0].GetHashCode();
            }
