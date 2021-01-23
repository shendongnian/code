    public class OpusOneConvention : IConventionPack
        {
            public IEnumerable<IConvention> Conventions
            {
                get { return new List<IConvention> { new IgnoreIfNullConvention(true) }; }
            }
        }
