    SomeClass<Foo> fooClass = new SomeClass<Foo>():
    //do stuff to fooClass
    SomeClass<Baz> = fooClass.ChangeSet<Baz>();
    
    public class SomeClass<T> where T : class
    {
        public SomeClass<K> ChangeSet<K>() where K:class
        {
           var changed = new SomeClass<K>();
           //manually map the properties over
           //but how do you know that Foo.PropertyA fits into Baz.PropetyZed?
           //what happens if Foo.A has a string length of 100, but Baz.A has a max length of 50? What do you do?
           //What id Foo.ID is an INT and Baz.ID is a GUID?
           return changed;
        }
    }
