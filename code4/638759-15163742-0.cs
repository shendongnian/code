    public class MyColumnRule<T> : IColumnRule<T>
    {
        ...
 
        public T Parse(string rowdata)
        {
            // strong-typed parse method
        }
        object IColumnRule.Parse(string rowdata)
        {
            return this.Parse(rowdata); // invokes strong-typed method.
        }
    }
