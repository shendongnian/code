    internal static class ListDataExtension
    {
        public static int MaxDepthOfTree(this List<Data> dataList)
        {
            return dataList.Max(data => data.MaxDepthOfTree);
        }
    }
    internal class Data
    {
        public int number;
        public List<Data> info;
        public int MaxDepthOfTree
        {
            get 
            { 
                return GetDepth(1); 
            }
        }
        int GetDepth(int depth)
        {
            if (info == null)
                return depth;
            var maxChild = info.Max(x => x.GetDepth(depth));
            return maxChild + 1;
        }
    }
