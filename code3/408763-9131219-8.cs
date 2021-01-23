    /// <summary>
    /// The abstract level configuration allows descendent classes to configure themselves
    /// </summary>
    public abstract class LevelConfiguration
    {
        protected Random Random = new Random();
        private Dictionary<Level, ProblemConfiguration> _configurableLevels = new Dictionary<Level, ProblemConfiguration>();
        /// <summary>
        /// Adds a configurable level.
        /// </summary>
        /// <param name="level">The level to add.</param>
        /// <param name="problemConfiguration">The problem configuration.</param>
        protected void AddConfigurableLevel(Level level, ProblemConfiguration problemConfiguration)
        {
            _configurableLevels.Add(level, problemConfiguration);
        }
        /// <summary>
        /// Removes a configurable level.
        /// </summary>
        /// <param name="level">The level to remove.</param>
        protected void RemoveConfigurableLevel(Level level)
        {
            _configurableLevels.Remove(level);
        }
        /// <summary>
        /// Returns all the configurable levels.
        /// </summary>
        public IEnumerable<Level> GetConfigurableLevels()
        {
            return _configurableLevels.Keys;
        }
        
        /// <summary>
        /// Gets the problem configuration for the specified level
        /// </summary>
        /// <param name="level">The level.</param>
        public ProblemConfiguration GetProblemConfiguration(Level level)
        {
            return _configurableLevels[level];
        }
    }
