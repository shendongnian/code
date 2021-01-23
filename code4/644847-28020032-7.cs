    /// <summary>
    /// Represents the state when the car is off
    /// </summary>
    internal class OffState : CarBaseState
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        /// </exception>
        public override string Message { get { return "Off"; } }
    }
    /// <summary>
    /// Represents the state when the car is idling
    /// </summary>
    internal class IdleState : CarBaseState
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        /// </exception>
        public override string Message { get { return "Idling"; } }
    }
