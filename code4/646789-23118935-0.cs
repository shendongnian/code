    public class ListModel<T>
    {
        public List<T> Items { get; set; }
        public ListModel(List<T> list) {
            Items = list;
        }
    }
