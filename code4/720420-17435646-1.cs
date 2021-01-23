    public static class DataBlobFactory
    {
        public IDataBlob GetDataBlob(string prop)
        {
            return new SomeDataBlob(prop);
        }
        // so on.
    }
