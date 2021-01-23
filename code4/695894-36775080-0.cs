    /// <summary>
    /// Generic singleton class, providing the Instance property, and preventing manual construction.
    /// Designed as a base for inheritance trees of lazy, thread-safe, singleton classes.
    /// Usage:
    /// 1. Sub-class must use itself, or its sub-class, as the type parameter S.
    /// 2. Sub-class must have a public default constructor (or no constructors).
    /// 3. Sub-class might be abstract, which requires it to be generic and demand the generic type
    ///    have a default constructor. Its sub-classes must answer all these requirements as well.
    /// 4. The instance is accessed by the Instance getter. Using a constructor causes an exception.
    /// 5. Accessing the Instance property in an inner initialization in a sub-class constructor
    ///    might cause an exception is some environments.
    /// </summary>
    /// <typeparam name="S">Lowest sub-class type.</typeparam>
    public abstract class Singleton<S> where S : Singleton<S>, new()
    {
        private static bool IsInstanceCreated = false;
        private static readonly Lazy<S> LazyInstance = new Lazy<S>(() =>
            {
                S instance = new S();
                IsInstanceCreated = true;
                return instance;
            });
        protected Singleton()
        {
            if (IsInstanceCreated)
            {
                throw new InvalidOperationException("Constructing a " + typeof(S).Name +
                    " manually is not allowed, use the Instance property.");
            }
        }
        public static S Instance
        {
            get
            {
                return LazyInstance.Value;
            }
        }
    }
