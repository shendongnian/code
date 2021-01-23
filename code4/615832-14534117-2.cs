    public class Entity
    {
        public IList<string> Type1Collection { get; set; }
        public IList<string> Type2Collection { get; set; } 
    }
    public class ConsumingClass
    {
        public void Example()
        {
            var entity = new Entity();
            entity.PublicMethod();
        }
    }
    public static class IterationExample
    {
        private static readonly Dictionary<bool, Action<Entity>> dictionary;
        static IterationExample()
        {
            dictionary = new Dictionary<bool, Action<Entity>> { { true, CollectionOneIterator }, { false, CollectionTwoIterator } };
        }
        public static void PublicMethod(this Entity entity)
        {
            dictionary[condition]();
        }
        private static void CollectionOneIterator(Entity entity)
        {
            foreach (var loopVariable in entity.Type1Collection)
            {
                //Your code here
            }
        }
        private static void CollectionTwoIterator(Entity entity)
        {
            foreach (var loopVariable in entity.Type2Collection)
            {
                //Your code here
            }
        }
    }
