    internal sealed class DoThis : Operation
    {
        internal DoThis(MyForm form) : base(form) { }
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
        internal DoSomethingElse(MyForm form) : base(form) { }
        public override String DisplayName
        {
            get { return "Do something else!"; }
        }
        internal override void Execute()
        {
            // Code to do something else.
        }
    }
