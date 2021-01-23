    // I made this sealed to ensure that `this.GetType()` will always be a generic
    // type of `AnotherClass<>`.
    public sealed class AnotherClass<T>
    {
        public AnotherClass(){
            var myType = ((PropertyInfo)
                    this.GetType()
                        .GetGenericArguments()[0]
                        .GetMember("AProperty")[0])
                .GetValue(null, null).Dump();
        }
    }
