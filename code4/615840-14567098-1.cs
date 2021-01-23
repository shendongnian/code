    public interface IMyType
    {
        String Notes { get; set; }
        decimal Price { get; set; }
    }
    public partial class Type1 : IMyType {}
    public partial class Type2 : IMyType {}
