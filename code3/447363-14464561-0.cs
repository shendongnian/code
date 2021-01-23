    public class SaveFileDialogMessage : GenericMessage<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SaveFileDialogMessage" /> class.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="callback">The callback.</param>
        public SaveFileDialogMessage(string content, string filter, Action<bool?, string> callback)
            : base(content)
        {
            Filter = filter;
            Callback = callback;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SaveFileDialogMessage" /> class.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="content">The content.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="callback">The callback.</param>
        public SaveFileDialogMessage(object sender, string content, string filter, Action<bool?, string> callback)
            : base(sender, content)
        {
            Filter = filter;
            Callback = callback;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SaveFileDialogMessage" /> class.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="target">The target.</param>
        /// <param name="content">The content.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="callback">The callback.</param>
        public SaveFileDialogMessage(object sender, object target, string content, string filter, Action<bool?, string> callback)
            : base(sender, target, content)
        {
            Filter = filter;
            Callback = callback;
        }
        /// <summary>
        /// Gets a callback method that should be executed to deliver the result
        /// of the message box to the object that sent the message.
        /// </summary>
        public Action<bool?, string> Callback { get; private set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
        /// <summary>
        /// Sets or gets the filter property.
        /// </summary>
        public string Filter { get; set; }
        /// <summary>
        /// Utility method, checks if the <see cref="Callback" /> property is
        /// null, and if it is not null, executes it.
        /// </summary>
        /// <param name="result">The result that must be passed
        /// to the dialog message caller.</param>
        /// <param name="fileName">Name of the file.</param>
        public void ProcessCallback(bool? result, string fileName)
        {
            if (Callback != null)
            {
                Callback(result, fileName);
            }
        }
