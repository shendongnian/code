    public class Foo
    {
        public Foo(params KeyValuePair<object, object>[] myArgs)
        {
            var argsDict = myArgs.ToDictionary(k=>k.Key, v=>v.Value);
            // do something with argsDict
        }
    }
