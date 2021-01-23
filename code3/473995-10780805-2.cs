    public static class MyContext_Extensions
    {
        public static ObjectResult<Nullable<global::System.Int32>> SomeProc(this MyContext context,
            Nullable<global::System.Int32> mandatoryField, 
            Nullable<global::System.Int32> optionalField1 = null, 
            Nullable<global::System.DateTime> optionalField2 = null)
        {
            return context.SomeProc(mandatoryField, optionalField1, optionalField2);
        }
    }
