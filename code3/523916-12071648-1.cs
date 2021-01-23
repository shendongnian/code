    internal class UtilClass : IMyPublicInterface 
    { 
    }
    namespace MyProject 
    {
        public class PublicClass 
        {
            public IMyPublicInterface DoSomething() {} 
            public IMyPublicInterface { get; }
        }
    }
