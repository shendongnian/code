    /// <summary>
    /// Class BaseJsonService.
    /// </summary>
    public abstract class BaseJsonService
    {
        /// <summary>
        /// The client
        /// </summary>
        protected WebClient client;
    
        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <typeparam name="TResponse">The type of the attribute response.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="onComplete">The configuration complete.</param>
        /// <param name="onError">The configuration error.</param>
        public abstract void Get<TResponse>(string url, Action<TResponse> onComplete, Action<Exception> onError);
        /// <summary>
        /// Sends the specified URL.
        /// </summary>
        /// <typeparam name="TResponse">The type of the attribute response.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="jsonData">The json data.</param>
        /// <param name="onComplete">The configuration complete.</param>
        /// <param name="onError">The configuration error.</param>
        public abstract void Post<TResponse>(string url, string jsonData, Action<TResponse> onComplete, Action<Exception> onError);
    }
