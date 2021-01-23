        public class InventoryItemQuantityRandomGenerator
    {
        private readonly Random _random;
        private readonly IQueryable<int> _quantities;
        public InventoryItemQuantityRandomGenerator(IRepository database, int max)
        {
            _quantities = database.AsQueryable<ReceiptItem>()
                .Where(x => x.Quantity <= max)
                .GroupBy(x => x.Quantity)
                .Select(x => new
                                 {
                                     Quantity = x.Key,
                                     Count = x.Count()
                                 })
                .SelectMany(x => Enumerable.Repeat(x.Quantity, x.Count));
            _random = new Random();
        }
        public int Next()
        {
            return _quantities.ElementAt(_random.Next(0, _quantities.Count() - 1));
        }
    }
