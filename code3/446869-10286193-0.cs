     public class NullableByteToNullableIntConverter : ITypeConverter<Byte?, Int32?>
        {
            public Int32? Convert(ResolutionContext context)
            {
                return context.IsSourceValueNull ? (int?) null : System.Convert.ToInt32(context.SourceValue);
            }
        }
