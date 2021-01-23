    SomeClass<Foo> fooClass = new SomeClass<Foo>():
    //do stuff to fooClass
    SomeClass<Baz> = fooClass.ChangeSet<Baz>();
    
    public class SomeClass<T> where T : class
    {
        public SomeClass<K> ChangeSet<K>() where K:class
        {
           var changed = new SomeClass<K>();
            //manually map the properties over
           return changed;
        }
    }
