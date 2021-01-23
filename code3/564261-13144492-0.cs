       public class CreateMomentoCommandToMomentoConverter : ITypeConverter<CreateMomentoCommand, Momento>
        {
            public Momento Convert(ResolutionContext context)
            {
                var source = (CreateMomentoCommand) context.SourceValue;
                var momento = new Momento {Username = source.Username};
    
                return momento;
            }
        }
