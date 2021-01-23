    internal class CarStateManager
    {
        #region Fields
        Dictionary<string, ICarState> _stateStore = null;
        #endregion
        #region Properties
        /// <summary>
        /// Gets (or privately sets) the state of the current.
        /// </summary>
        /// <value>
        /// The state of the current.
        /// </value>
        internal ICarState CurrentState { get; private set;  }
        #endregion
        #region Constructors and Initialisation
        /// <summary>
        /// Initializes a new instance of the <see cref="StateManager"/> class.
        /// </summary>
        public CarStateManager()
        {
            _stateStore = new Dictionary<string, ICarState>();
        }
        #endregion
        #region Methods
        /// <summary>
        /// Adds a state.
        /// </summary>
        /// <param name="stateId">The state identifier.</param>
        /// <param name="state">The state.</param>
        public void AddState(string stateId, ICarState state)
        {
            // Add the state to the collection
            _stateStore.Add(stateId, state);
        }
        /// <summary>
        /// Changes the state.
        /// </summary>
        /// <param name="stateId">The state identifier.</param>
        public void ChangeState(string stateId)
        {
            // Set thr current state
            CurrentState = _stateStore[stateId];
        }
        #endregion
    }
