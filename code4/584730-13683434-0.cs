        public static void Sort(List<Result> listToSort)
        {
            listToSort.Sort(new ResultComparator());
        }
        public class ResultComparator : IComparer<Result>
        {
            public int Compare(Result x, Result y)
            {
                if (x == null && y == null) return 0;
                if (x == null) return 1;
                if (y == null) return 0;
                // compare based in SN
                return string.Compare(x.SN, y.SN);
            }
        }
