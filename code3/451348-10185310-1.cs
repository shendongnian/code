    // ...
        Type t = typeof(HashSet<int>);
        bool test1 = GenericClassifier.IsICollection(t); // true
        bool test2 = GenericClassifier.IsIEnumerable(t); // true
    }
    //
    public static class GenericClassifier {
        public static bool IsICollection(Type type) {
            return Array.Exists(type.GetInterfaces(), IsGenericCollectionType);
        }
        public static bool IsIEnumerable(Type type) {
            return Array.Exists(type.GetInterfaces(), IsGenericEnumerableType);
        }
        static bool IsGenericCollectionType(Type type) {
            return type.IsGenericType && (typeof(ICollection<>) == type.GetGenericTypeDefinition());
        }
        static bool IsGenericEnumerableType(Type type) {
            return type.IsGenericType && (typeof(IEnumerable<>) == type.GetGenericTypeDefinition());
        }
    }
