    public abstract class ResourceBase
    {
        // Records how to make a ResourceBase from a string, 
        // on a per-extension basis
        private static Dictionary<string, Func<string, ResourceBase>> constructorMap
            = new Dictionary<string, Func<string, ResourceBase>>();
        // Allows a derived type to subscribe itself
        protected static void Subscribe(
            string extension, 
            Func<string, ResourceBase> ctor)
        {
            if (constructorMap.ContainsKey(extension))
                throw new Exception("nuh uh");
            constructorMap.Add(extension, ctor);
        }
        // Given a string, finds out who has signed up to deal with it,
        // and has them deal with it
        public static implicit operator ResourceBase(string s)
        {
            // Find a matching extension
            var matches = constructorMap.Where(kvp => s.EndsWith(kvp.Key)).ToList();
            switch (matches.Count)
            {
                case 0:
                    throw new Exception(
                      string.Format("Don't know how to make {0} into a ResourceBase",
                                    s));
                case 1:
                    return matches.Single().Value(s);
                default:
                    throw new Exception(string.Format(
                      "More than one possibility for making {0} into a ResourceBase",
                      s));
            }
        }
    }
