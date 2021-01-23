    public abstract class Builder
    {
        public static TBuilder GetBuilder<TBuilder>() where TBuilder : Builder
        {
            var ctors = typeof(TBuilder).GetConstructors(
                BindingFlags.Instance | 
                BindingFlags.NonPublic | 
                BindingFlags.Public);
            var matchingCtor = ctors.Single(
                ci =>
                    {
                        var paramInfo = ci.GetParameters();
                        if (paramInfo.Length != parameters.Length)
                        {
                            return false;
                        }
                        return !paramInfo.Where((t, i) =>
                            t.ParameterType != parameters[i].GetType()).Any();
                    });
            return (TBuilder)matchingCtor.Invoke(parameters);
        }
    }
