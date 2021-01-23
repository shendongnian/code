    public interface IHasQuantity { double Quantity { get; } }
    public interface IHasPrice { decimal PricePerUnit { get; } }
    public static class TraitExtensions
    {
        public static decimal CalculateTotalPrice<T>(this T instance)
            where T : class, IHasPrice, IHasQuantity
        {
            return (decimal)instance.Quantity * instance.PricePerQuantity;
        }
    }
