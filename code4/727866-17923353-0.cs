    public class ClassC
    {
        public DataTable DataTableValue { get; set; }
        private Task<byte[]> serializeDataTask;
        public void SerializeDataTable()
        {
            serializeDataTask = Task.Factory.StartNew( () => this.DataTableValue.SerializeToByteArray() );
        }
        public Task<byte[]> GetSerializedDataTable()
        {
            // You can either throw or start it lazily if SerializeDataTable hasnt been called yet.
            if ( serializeDataTask == null ) 
                throw new InvalidOperationException();
            return serializeDataTask;
        }
    }
