    interface IHasComplexType
    {
        ComplexType  GetComplexType();
    }
      
    public class MyViewModel : IHasComplexModel
    {
        public ComplexType GetComplexType() { return MyComplexType;}
    }
