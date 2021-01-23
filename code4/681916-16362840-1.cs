    /// <summary>
    /// Immutable, created by the server
    /// </summary>
    class LoginResult
    {
        /// <summary>
        /// Null in the case of failure
        /// </summary>
        public int? Id { get; private set; }
        /// <summary>
        /// Null in the case of success
        /// </summary>
        public string FailReason { get; private set; }
        /// <summary>
        /// Always >= 1
        /// </summary>
        public int AttemptNumber { get; private set; }
        public LoginResult(int id, int attemptNumber)
        {
            Id = id;
            AttemptNumber = attemptNumber;
        }
        public LoginResult(string reason, int attemptNumber)
        {
            FailReason = reason;
            AttemptNumber = attemptNumber;
        }
    }
