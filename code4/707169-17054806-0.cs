    public class MyIndexedProperty
    {
        private int[,] Data { get; set; }
        public MyIndexedProperty()
        {
            Data = new int[10, 10];
        }
        public int this[int x, int y] {
            get
            {
                return Data[x, y];
            }
            set
            {
                Data[x, y] = value;
            }
        }
    }
