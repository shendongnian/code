    internal sealed class DoThis : Operation
    {
        public DoThis(MyForm form) : base(form) { }
        public override String DisplayName
        {
            get { return "Do this!"; }
        }
        internal override void Execute()
        {
            // Code to do this. You can use this.form to interact with
            // your form from this operation.
        }
    }
    internal sealed class DoSomethingElse : Operation
    {
        public DoSomethingElse(MyForm form) : base(form) { }
        public override String DisplayName
        {
            get { return "Do something else!"; }
        }
        internal override void Execute()
        {
            // Code to do something else.
        }
    }
