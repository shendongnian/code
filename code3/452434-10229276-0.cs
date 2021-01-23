    public class SomeClass
    {
        public void DoSomething<T>(IRelatable<T> rel)
            where T : Entity
        {
            T relatedTo = rel.RelatedEntity;
            // ...        
        }
    }
