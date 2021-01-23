    public class DivDecorator
    {
        public static readonly IDecorator Instance = new DivDecorator();
    }
    ...
    grid.Decorator = Com.MyCompany.DivDecorator.Instance;
