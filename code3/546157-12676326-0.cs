    public interface IDelegatedValidation : IDataErrorInfo
    {
        /// <summary>
        /// Occurs when validation is to be performed.
        /// </summary>
        event EventHandler<DelegatedValidationEventArgs> ValidationRequested;
    }
    public class DelegatedValidationEventArgs : EventArgs
    {
        public DelegatedValidationEventArgs(string propertyName)
        {
            this.PropertyName = propertyName;
        }
        public string PropertyName { get; private set; }
        public bool Handled { get; set; }
        public string ValidationError { get; set; }
    }
