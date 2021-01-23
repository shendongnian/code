    public static class AdverntureWorks_CentralEntities112
    {
        public static ObjectResult<Nullable<global::System.Int32>> SomeProc(this AdverntureWorks_CentralEntities context,
            Nullable<global::System.Int32> mandatoryField, 
            Nullable<global::System.Int32> optionalField1 = null, 
            Nullable<global::System.DateTime> optionalField2 = null)
        {
            return context.SomeProc(mandatoryField, optionalField1, optionalField2);
        }
    }
