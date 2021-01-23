    public class MyData
    {
        public MyData(string description, int colorId, int quantity)
        {
            Description = description;
            ColorId = colorId;
            Quantity = quantity;
        }
        public string Description {get; private set; }
        public int ColorId {get; private set; }
        public int Quantity {get; private set; }
    }
    ...
    public static readonly ReadOnlyCollection<MyData> refData =
        new ReadOnlyCollection<MyData>(
            new [] {
                new MyData("Brown Bear", 0x88,   10),
                new MyData("Blue Horse", 0x666,  42),
                new MyData("Purple Cat", 123456, 50)
                });
