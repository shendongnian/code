    internal abstract class Operation
    {
        protected readonly MyForm form = null;
        protected Operation(MyForm form)
        {
            this.form = form;
        }
        public abstract String DisplayName { get; }
        internal abstract void Execute();
    }
