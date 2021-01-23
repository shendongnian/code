    namespace ConsoleApplication1
    {
        namespace SomeOtherSpace
        {
            public class TokenWrapper
            {
                public CancellationToken CancelToken { get; set; }
            }
        }
    
        namespace YetAnotherSpace
        {
            public class AnotherClass
            {
                private readonly CancellationToken _Token;
                public AnotherClass(CancellationToken token)
                {
                    _Token = token;
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                SomeOtherSpace.TokenWrapper wrapper = new SomeOtherSpace.TokenWrapper();
                wrapper.CancelToken = new CancellationToken();
                YetAnotherSpace.AnotherClass anotherClass = new YetAnotherSpace.AnotherClass(wrapper.CancelToken);
            }
        }
    }
