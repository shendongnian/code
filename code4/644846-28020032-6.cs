    /// <summary>
    /// The class that all car states should inherit from.
    /// </summary>
    internal abstract class CarBaseState : ICarState
    {
        #region ICarState Members
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        /// </exception>
        public abstract string Message { get; }
        #endregion
    }
