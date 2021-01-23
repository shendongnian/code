    public interface IMyType
    {
        String Notes { get; set; }
        decimal Price { get; set; }
    }
    public static class MyTypeExtensions
    {
        public static void MyLogic(this IMyType myType)
        {
            // whatever other logic is needed
            myType.Notes = "notes";
            myType.Price = 1;
        }
     }
