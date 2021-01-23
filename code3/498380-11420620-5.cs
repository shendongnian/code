    class Program
    {
        static void Main()
        {
            ObjectFactory.Configure(x=>x.AddRegistry<CoreRegistry>());
            var instance = ObjectFactory.GetInstance(typeof(IRenderer<string>)) as IRenderer<Generic<string>>;
            var render = instance.Render(new Generic<string>());
        }
    }
