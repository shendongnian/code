    public class MyItemCollection : IList<MyItem>
    {
        private List<MyItem> _list;
        public MyItemCollection()
        {
            _list = new List<MyItem>();
        }
        public void Add(MyItem item)
        {
            if (item.IsComplete)
            {
                _list.Add(item);
            }
            else
            {
                throw new InvalidOperationException("Unable to add an incomplete item");
            }
        }
        //Then you have to implement all the IList interface members...
    }
