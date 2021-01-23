    public interface IHasNext<T> where T : IHasNext<T>
    {
        T NextItem { get; set; }
    }
    public class Item : IHasNext<Item>
    {
        public int Id { get; set; }
        IHasNext<Item> NextItem { get; set; }
    }
