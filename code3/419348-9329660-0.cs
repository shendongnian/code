    public interface IRegistrar {
        Foo GetFoo(string id);
        Bar GetBar(string id);
    }
    var myFoo = _registrar.GetFoo(id);
