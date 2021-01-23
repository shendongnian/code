    public class ListWrapper
    {
        private List<int> list = ...
    
        public int this[int index]
        {
            return list[index];
        }
    }
