    public partial class MyContext
    {
        public ObjectResult<Nullable<global::System.Int32>> SomeProc(
            Nullable<global::System.Int32> mandatoryField,
            Nullable<global::System.Int32> optionalField1 = null)
        {
            return this.SomeProc(mandatoryField, optionalField1, null);
        }
    }
