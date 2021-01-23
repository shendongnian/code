    /// <summary>
    /// The only responsibility of the factory is to create instances of Problems and know what kind of problems it can create, 
    /// it should not know about configuration
    /// </summary>
    public class ProblemFactory
    {
        private Dictionary<Type, Func<Level, IProblem>> _registeredProblemTypes; // this associates each type with a factory function
        /// <summary>
        /// Initializes a new instance of the <see cref="ProblemFactory"/> class.
        /// </summary>
        public ProblemFactory()
        {
            _registeredProblemTypes = new Dictionary<Type, Func<Level, IProblem>>();
        }
        /// <summary>
        /// Registers a problem factory function to it's associated type
        /// </summary>
        /// <typeparam name="T">The Type of problem to register</typeparam>
        /// <param name="factoryFunction">The factory function.</param>
        public void RegisterProblem<T>(Func<Level, IProblem> factoryFunction)
        {
            _registeredProblemTypes.Add(typeof(T), factoryFunction);
        }
        /// <summary>
        /// Generates the problem based on the type parameter and invokes the associated factory function by providing some problem configuration
        /// </summary>
        /// <typeparam name="T">The type of problem to generate</typeparam>
        /// <param name="problemConfiguration">The problem configuration.</param>
        /// <returns></returns>
        public IProblem GenerateProblem<T>(Level level) where T: IProblem
        {
            // some extra safety checks can go here, but this should be the essense of a factory,
            // the only responsibility is to create instances of Problems and know what kind of problems it can create
            return _registeredProblemTypes[typeof(T)](level); 
        }
    }
