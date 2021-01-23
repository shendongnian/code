    [DebuggerType("CategoryDebugView")]
    [Flags]
    public enum Categories : uint
    {
        ...
    }
    internal class CategoryDebugView
    {
        private Category value;
        public CategoryDebugView(Category value)
        {
            this.value = value;
        }
        public override string ToString()
        {
            var categoryNames =
                from v in Enum.GetValues(typeof(Categories)).Cast<Category>()
                where v & c == c
                orderby v
                select v.ToString();
            return String.Join(", ", categoryNames);
        }
    }
