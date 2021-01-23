        public class Accessor<T> : IAnimalAccessor where T : Animal
        {
            private readonly Dictionary<string, T> _dict;
            public Accessor(Dictionary<string, T> dict)
            {
                _dict = dict;
            }
            public Animal GetItem(String key)
            {
                return _dict[key];
            }
        }
        public interface IAnimalAccessor
        {
            Animal GetItem(string key);
        }
        public static void DoStuffWithAnimals(IAnimalAccessor getAnimal)
        {
        }
        var dicLions = new Dictionary<string, Lion>();
        var accessor = new Accessor<Lion>(dicLions);
        DoStuffWithAnimals(accessor);
