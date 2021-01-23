        /// <summary>
        /// Bootstrap the wrapper class
        /// </summary>
        static Logger()
        {
            LogManager.AddHiddenAssembly(typeof(LoggingExtensions).Assembly);
        }
