    public class MyMessageComparer : IComparer<MessageType> {
        protected IList<MessageType> orderedTypes {get; set;}
        
        public MyMessageComparer() {
            // you can reorder it's all as you want
            orderedTypes = new List<MessageType>() {
                MessageType.Boo,
                MessageType.Bar,
                MessageType.Foo,
                MessageType.Doo,
            };
        }
        
        public int Compare(MessageType x, MessageType y) {
            var xIndex = orderedTypes.IndexOf(x);
            var yIndex = orderedTypes.IndexOf(y);
            return xIndex.CompareTo(yIndex);
        }
    };
