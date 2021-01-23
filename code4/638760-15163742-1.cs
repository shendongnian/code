    public abstract class ColumnRule : IColumnRule
    {
        ...
        public object Parse(string rowdata)
        {
            return this.ParseInternal(rowdata);
        }
        protected abstract object ParseInternal(rowdata);
    }
    public class ColumnRule<T> : ColumnRule, IColumnRule<T>
    {
        ...
 
        public new T Parse(string rowdata)
        {
            // strong-typed parse method
        }
        protected override object ParseInternal(string rowdata)
        {
            return this.Parse(rowdata); // invokes strong-typed method
        }
    }
