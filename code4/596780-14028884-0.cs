    interface IAlpha<TBeta> where TBeta : IBeta
    {
        TBeta BetaProperty { get; set; }
    }
    ...
    public class Alpha : IAlpha<Beta>
