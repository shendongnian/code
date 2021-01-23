    public class Generator
    {
        private int index = 0;
        private List<string> list1 = new List<string> { "a", "b" };
        private List<string> list2 = new List<string> { "c", "d" };
        private List<string> list3 = new List<string> { "e", "f", "g" };
        public string Next()
        {
            int indexList3 = index % list3.Count;
            int indexList2 = (index / list3.Count) % list2.Count;
            int indexList1 = (index / (list2.Count * list3.Count)) % list1.Count;
            IncrementIndex();
            return list1[indexList1] + list2[indexList2] + list3[indexList3];
        }
        private void IncrementIndex()
        {
            index++;
            if (index > list1.Count*list2.Count*list3.Count)
            {
                index = 0;
            }
        }
    }
