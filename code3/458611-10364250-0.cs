    public class MyItemCollection : List<MyItem>
    {
        public override void Add(MyItem item)
        {
            if (item.IsComplete)
            {
                base.Add(item);
            }
            else
            {
                throw new InvalidOperationException("Unable to add an incomplete item");
            }
        }
    }
