    public class InnerObjectResolver : ValueResolver<Table, Table>
    {
        protected override Table ResolveCore(Table source)
        {
            return source;
        }
