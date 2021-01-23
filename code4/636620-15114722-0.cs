    public class Item : IHasNext
    {
        public int Id { get; set; }
        IHasNext NextItem { get; set; }
    }
