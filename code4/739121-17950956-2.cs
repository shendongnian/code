    public class Grid
    {
        public Type DecoratorType { get; set; }
        
        private IDecorator CreateDecorator()
        {
            return (IDecorator)Activator.CreateInstance(this.DecoratorType);
        }
    }
    ...
    grid.Decorator = typeof(Com.MyCompany.DivDecorator);
