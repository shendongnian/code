    public class StateResolver : IValueResolver
    {
        public ResolutionResult Resolve(ResolutionResult source)
        {
            return source.New(DomainEntityState.Unchanged);
        }
    }
