    public class TrackedErrorProvider : ErrorProvider
    {
        public TrackedErrorProvider() : base() { }
        public TrackedErrorProvider(ContainerControl parentControl) : base(parentControl) { }
        public TrackedErrorProvider(IContainer container) : base(container) { }
        public int ErrorsCount { get; protected set; } = 0;
        public bool HasErrors
        {
            get { return ErrorsCount > 0; }
        }
        public new void SetError(Control control, string message)
        {
            //Check if there is already an error linked to the control
            bool errorExistsForControl = !string.IsNullOrEmpty(GetError(control));
            //If removing error from the control
            if (string.IsNullOrEmpty(message))
            {
                /* Decreases the counter only if:
                *   - an error already existed for the control
                *   - the counter is not 0
                */
                if (errorExistsForControl && ErrorsCount > 0) ErrorsCount--;
            }
            else //If setting error message to the control
            {
                //Increments the error counter only if an error wasn't set for the control (otherwise it is just replacing the error message)
                if (!errorExistsForControl) ErrorsCount++;
            }
            base.SetError(control, message);
        }
        public void RemoveError(Control control)
        {
            SetError(control, null);
        }
    }
