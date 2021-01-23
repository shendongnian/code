        public sealed class Outer
        {
            private interface IInnerFactory
            {
                Inner CreateInner(string text);
            }
            private static IInnerFactory InnerFactory = new Inner.Factory();
            public Inner Item(string text)
            {
                return InnerFactory.CreateInner(text);
            }
            public sealed class Inner
            {
                public class Factory : IInnerFactory
                {
                    Inner IInnerFactory.CreateInner(string text)
                    {
                        return new Inner(text);
                    }
                }
                private Inner(string value) 
                {
                    text = value;
                }
                public string Text { get { return text; } }
                readonly string text;
            }
        }
    }
	
