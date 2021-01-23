    public interface IHasNext<T>
    {
        T NextItem { get; set; }
    }
     public class Item : IHasNext<Item>
     {
        public int Id { get; set; }
        Item NextItem { get; set; }
     }
