    /// <summary>
    /// Represents errors that occur during application execution.
    /// </summary>
    [DataContract]
    public class ExceptionInfo
    {
        /// <summary>
        /// Gets the type of the exception.
        /// </summary>
        [DataMember]
        public string ExceptionType
        {
            get;
            set;
        }
        /// <summary>
        /// Gets a message that describes the current exception.
        /// </summary>
        /// <returns>
        /// The error message that explains the reason for the exception, or an empty string("").
        /// </returns>
        [DataMember]
        public string Message
        {
            get;
            set;
        }
        /// <summary>
        /// Gets the <see cref="T:System.Exception"/> instance that caused the current exception.
        /// </summary>
        /// <returns>
        /// An instance of Exception that describes the error that caused the current exception. The InnerException property returns the same value as was passed into the constructor, or a null reference (Nothing in Visual Basic) if the inner exception value was not supplied to the constructor. This property is read-only.
        /// </returns>
        [DataMember]
        public ExceptionInfo InnerException
        {
            get;
            set;
        }
        /// <summary>
        /// Gets a string representation of the immediate frames on the call stack.
        /// </summary>
        /// <returns>
        /// A string that describes the immediate frames of the call stack.
        /// </returns>
        [DataMember]
        public string StackTrace
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets a link to the help file associated with this exception.
        /// </summary>
        /// <returns>
        /// The Uniform Resource Name (URN) or Uniform Resource Locator (URL).
        /// </returns>
        [DataMember]
        public string HelpLink
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the name of the application or the object that causes the error.
        /// </summary>
        [DataMember]
        public string Source
        {
            get;
            set;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionInfo"/> class.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <exception cref="ArgumentNullException">exception</exception>
        public ExceptionInfo(Exception exception)
        {
            if(exception == null)
                throw new ArgumentNullException("exception");
            ExceptionType = exception.GetType().FullName;
            HelpLink = exception.HelpLink;
            Message = exception.Message;
            Source = exception.Source;
            StackTrace = exception.StackTrace;
            if(exception.InnerException != null)
            {
                InnerException = new ExceptionInfo(exception.InnerException);
            }
        }
    }
