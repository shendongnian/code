    public class MyItemList : List<MyItem>
    {
    	public MyItemList(){}
    
    	public MyItemList(IEnumerable<MyItem> sequence): base(sequence) {}
        public MyItemList cutOff(int count)
        {
            MyItemList result = new MyItemList(this.GetRange(0, count));
            this.RemoveRange(0, count);
            return result;
        }
    }
