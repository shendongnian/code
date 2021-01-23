    public class SomeClass<T> where T: Entity
    {
        public void DoSomething(IRelatable<T> rel)
        {
            T relatedTo = rel.RelatedEntity;
            // ...
        }
    }
