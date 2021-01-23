    public class ExampleObject
    {
        /// <summary>
        /// A public property that can only be read.
        /// When a DataGridViewRow is populated with this object, the column representing this Boolean property is automatically read-only.
        /// </summary>
        public Boolean QCPassed
        {
            get;
            private set;
        }
    }
