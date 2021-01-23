    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            var foo = container.Resolve<MyController>();
        }
    }
    public class MyController
    {
        private IUnityContainer container;
        public MyController(IUnityContainer container)
        {
            this.container = container;
        }
    }
