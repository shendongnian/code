    /// <summary>
    /// The mapping view model.
    /// </summary>
    public class MappingViewModel
    {
        #region Public Properties
        /// <summary>
        /// Gets or sets the mappings.
        /// </summary>
        public IEnumerable<Mapping> Mappings { get; set; }
        public MappingViewModel()
        {
            //this.Mappings = new List<Mapping>();
            IEnumerable<Mapping> test = new HashSet<Mapping>();
        }
        public string FileName { get; set; }
        #endregion
    }
