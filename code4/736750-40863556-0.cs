    public class DodgyAssembly : Assembly
    {
        public override Type[] GetTypes()
        {
            throw new ReflectionTypeLoadException(new [] { typeof(Foo) }, new [] { new Exception() });
        }
    }
    var assembly = new DodgyAssembly();
