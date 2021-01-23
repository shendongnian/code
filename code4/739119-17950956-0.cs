    public class DivDecorator
    {
        public static IDecorator Create()
        {
            return new Com.MyCompany.DivDecorator()
        }
    }
    ...
    grid.Decorator = Com.MyCompany.DivDecorator.Create();
