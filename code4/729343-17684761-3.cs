    public class SomeClass
    {
        public void SomeDlsMethod()
        {
            TypeSwitch.Do(someDslObject,
                TypeSwitch.Case<DslObjectA>(someDslObjectA => ...),
                TypeSwitch.Case<DslObjectB>(someDslObjectB => ...),
                TypeSwitch.Default(() => ...)
            );
        }
    }
