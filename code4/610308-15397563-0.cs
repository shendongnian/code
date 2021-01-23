    public class LogAspect : OnMethodBoundaryAspect
    {
        /// <summary>
        /// Gets or sets the logger.
        /// </summary>
        public static ILogger logger { get; set; }
