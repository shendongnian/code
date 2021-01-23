    public class ParseTree
    {
        private string ownText;
        private List<ParseTree> children = new List<ParseTree>();
        public ParseTree(string name, ParseTree parent)
        {
            this.Parent = parent;
            this.Rule = name;
        }
        public String Text
        {
            get
            {
                if (this.IsTerminal) return this.ownText;
                else
                {
                    StringBuilder builder = new StringBuilder();
                    foreach (ParseTree child in children)
                    {
                        builder.Append(child.Text);
                    }
                    return builder.ToString();
                }
            }
            set
            {
                this.ownText = value;
            }
        }
        public ParseTree Parent { get; private set; }
        public string Rule { get; private set; }
        public List<ParseTree> Children { get { return children; } }
        public Boolean IsTerminal
        {
            get
            {
                return (children.Count == 0);
            }
        }
    }
    //Isn't this the silliest little thing you've ever seen?
    //Where is a pointer when you need one?
    public class C<T>
    {
        public T Value { get; set; }
    }
