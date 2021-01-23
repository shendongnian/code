    /// <summary>
    /// counting
    /// </summary>
    public class CountingStrategyConfigurationElement : StrategyConfigurationElement
    {
        /// <summary>
        /// constructor
        /// </summary>
        public CountingStrategyConfigurationElement() { }
        /// <summary>
        /// constructor
        /// </summary>
        public CountingStrategyConfigurationElement(string name) : base(name) { }
        /// <summary>
        /// The max number of requests
        /// </summary>
        [ConfigurationProperty("maxRequestNumber", IsKey = false, IsRequired = true)]
        public int MaxRequestNumber
        {
            get
            {
                return (int)this["maxRequestNumber"];
            }
            set
            {
                this["maxRequestNumber"] = value;
            }
        }
        /// <summary>
        /// Counting request in this range of time
        /// </summary>
        [ConfigurationProperty("countingTimeRange", IsKey = false, IsRequired = true)]
        public TimeSpan CountingTimeRange
        {
            get
            {
                return (TimeSpan)this["countingTimeRange"];
            }
            set
            {
                this["countingTimeRange"] = value;
            }
        }
        /// <summary>
        /// Counting Time Accuracy
        /// </summary>
        [ConfigurationProperty("countingTimeAccuracy", IsKey = false, IsRequired = true)]
        public TimeSpan CountingTimeAccuracy
        {
            get
            {
                return (TimeSpan)this["countingTimeAccuracy"];
            }
            set
            {
                this["countingTimeAccuracy"] = value;
            }
        }
    }
