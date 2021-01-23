    internal abstract class Operation
    {
        protected readonly MyForm form = null;
        protected Operation(MyForm form)
        {
            this.form = form;
        }
        public abstract String DisplayName { get; }
        protected abstract void ExecuteCore();
        internal void Execute()
        {
            Logger.Log("Executing operation " + this.DisplayName);
            try
            {
                this.ExecuteCore();
                Logger.Log("Executing operation " + this.DisplayName + " succeeded.");
            }
            catch (Exception exception)
            {
                Logger.Log("Executing operation " + this.DisplayName + " failed.", exception);
                throw;
            }
        }
    }
