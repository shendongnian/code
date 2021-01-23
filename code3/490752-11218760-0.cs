    public class OtherAssemblyBuilder
    {
        public TopClass Build()
        {
            return TopClass.GetInstance();
        }
        public SecondLevelClass Build()
        {
            TopClass top = TopClass.GetInstance();
            return top.CreateSecondLevelElement();
        }
        public ThirdLevelClass Build()
        {
            TopClass top = TopClass.GetInstance();
            SecondLevelClass secondLevel = top.CreateSecondLevelElement();
            return secondLevel.CreateThirdLevelElement();
        }
    }
