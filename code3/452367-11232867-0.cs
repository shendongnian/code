    [DelimitedRecord(",")]
    public class RequiredField
    {
        public string Required;
        public static FileHelperEngine GetEngine()
        {
            var result = new FileHelperEngine(typeof(RequiredField));
            result.AfterReadRecord += AfterReadValidation;
            return result;
        }
        private static void AfterReadValidation(EngineBase sender, AfterReadRecordEventArgs args)
        {
            if (String.IsNullOrWhiteSpace(((RequiredField)args.Record).Required))
            {
                throw new ConvertException("RequiredField is Null or WhiteSpace", typeof(String));
            }
        }
    }
