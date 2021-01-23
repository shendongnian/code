    SomeClass<C> c = new SomeClass<C();
    C another = c.CreateAnother(); // C is not assignable from B. (C is below). But It would be valid, if compiler did not flag the error
    public class C : IGeneralInterface, IDisposable
    {
    }
	
