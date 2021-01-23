    public static class ChannelSort
    {
        static Dictionary<Channel, int> _dict = new Dictionary<Channel, int>();
        public static int GetSort(this Channel c)
        {
            return _dict[c] //will throw if key's not found,
            //may want to handle it for more descriptive exception
        }
        public static int SetSort(this Channel c, int sort)
        {
            _dict[c] = sort;
        }
    }
