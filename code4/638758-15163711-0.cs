    public abstract ColumnRuleBase<T> : IColumnRule<T>
    {
        public object Parse(string toParse)
        {
            IColumnRule<T> genericThis = this;
            return genericThis.Parse(toParse);
        }
        ...
    }
