    public class MyItemList : List<MyItem>
    {
       // def ctor
       public MyItemList() {}
       public MyItemList(IEnumerable<MyItems> items): base(items) {}
       public MyItemList cutOff(int count)
        {
            MyItemList result = new MyItemList(this.GetRange(0, count));
            this.RemoveRange(0, count);
            return result;
        }
    }
