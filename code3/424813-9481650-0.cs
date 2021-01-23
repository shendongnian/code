    public sealed class Logging
    {
        // Constructor is lazily called.
        Logging()
        {
            //Setup reference to logging file.
        }
        public static Logging Instance
        {
            get
            {
                return Nested.instance;
            }
        }
        /// <summary>
        /// Writes debug information.
        /// </summary>
        /// <param name="text">The text to write.</param>
        public void Debug(String text)
        {
            //Log to file
        }
        /// <summary>
        /// Writes warning message.
        /// </summary>
        /// <param name="text">The message to write.</param>
        public void Warn(String text)
        {
            //Log to file
        }
        /// <summary>
        /// Writes error message.
        /// </summary>
        /// <param name="text">The message to write.</param>
        public void Error(String text)
        {
            //Log to file
        }
        /// <summary>
        /// Writes error message.
        /// </summary>
        /// <param name="text">The message to write.</param>
        /// <param name="e">An inner exception.</param>
        public void Error(String text, Exception e)
        {
            //Log to file
        }
        /// <summary>
        /// Private class to hold the instance of the singleton.
        /// </summary>
        class Nested
        {
            static Nested()
            {
            }
            internal static readonly Logging instance = new Logging();
        }
    }
