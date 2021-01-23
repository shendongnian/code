        public class ParseAdaptor : CommonTreeAdaptor
        {
            private C<ParseTree> container;
            public ParseAdaptor(C<ParseTree> container)
                : base()
            {
                this.container = container;
            }
            public override void AddChild(object t, object child)
            {
                base.AddChild(t, child);
                this.container.Value.Text += base.GetTree(child).Text;
            }
        }
