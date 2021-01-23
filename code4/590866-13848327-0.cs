    using System.Runtime.CompilerServices;
        
    class Item
    {
        [IndexerName("Bob")]
        public int this[int x] { get { return 0; } }
    }
