    /// <summary>
    /// Contains level configuration for Binary problems
    /// </summary>
    public class BinaryLevelConfiguration : LevelConfiguration
    {
        public BinaryLevelConfiguration()
        {
            AddConfigurableLevel(Level.Easy, GetEasyLevelConfiguration());
            AddConfigurableLevel(Level.Medium, GetMediumLevelConfiguration());
            AddConfigurableLevel(Level.Hard, GetHardLevelConfiguration());
        }
        /// <summary>
        /// Gets the hard level configuration.
        /// </summary>
        /// <returns></returns>
        private ProblemConfiguration GetHardLevelConfiguration()
        {
            return new ProblemConfiguration
            {
                MinValue = 100,
                MaxValue = 1000,
                Operator = Operator.Addition
            };
        }
        /// <summary>
        /// Gets the medium level configuration.
        /// </summary>
        /// <returns></returns>
        private ProblemConfiguration GetMediumLevelConfiguration()
        {
            return new ProblemConfiguration
            {
                MinValue = 10,
                MaxValue = 100,
                Operator = Operator.Addition
            };
        }
        /// <summary>
        /// Gets the easy level configuration.
        /// </summary>
        /// <returns></returns>
        private ProblemConfiguration GetEasyLevelConfiguration()
        {
            return new ProblemConfiguration
            {
                MinValue = 1,
                MaxValue = 10,
                Operator = Operator.Addition
            };
        }
      
    }
