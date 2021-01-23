    public class CalculatorModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOne>().ToMethod(CreateOne).Named("Val");
            Bind<IOne>().ToMethod(CreateTwo).Named("ED");
            Bind<ITwo>().ToMethod(CreateThree).Named("Val");
            Bind<ITwo>().ToMethod(CreateFour).Named("ED");
            Bind<IThree>().To<ClassFive>();
            Bind<ICalculator>().To<MyCalculator>();
        }
        private ITwo CreateFour(IContext arg)
        {
            return new ClassFour();
        }
        private ITwo CreateThree(IContext arg)
        {
            return new ClassThree();
        }
        private IOne CreateOne(IContext context)
        {
            return new ClassOne("filePath1");
        }
        private IOne CreateTwo(IContext arg)
        {
            return new ClassTwo("filePath2");
        }
       
    }
