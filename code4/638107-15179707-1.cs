    // I split this into a separate interface simply to make the boundary between
    // canceller and cancellee explicit, similar to CancellationTokenSource itself.
    public interface ITokenSource
    {
        CancellationToken Token { get; }
    }
    public class InterAppDomainCancellable: MarshalByRefObject,
                                            ITokenSource,
                                            IDisposable
    {
        public InterAppDomainCancellable()
        {
            cts = new CancellationTokenSource();
        }
        public void Cancel() { cts.Cancel(); }
        // Explicitly implemented to make it less tempting to call Token
        // from the wrong side of the boundary.
        CancellationToken ITokenSource.Token { get { return cts.Token; } }
        public void Dispose() { cts.Dispose(); }
        private readonly CancellationTokenSource cts;
    }
    // ...
    // Crucial difference here is that the remotable cancellation source
    // also lives in the other domain.
    interAppDomainCancellable = childDomain.CreateInstanceAndUnwrap(...);
    
    var primaryCts = new CancellationTokenSource();
    // Cancel the secondary when the primary is cancelled.
    primaryCts.Token.Register(() => interAppDomainCancellable.Cancel());
    objectInRemoteAppDomain = childDomain.CreateInstanceAndUnwrap(...);
    // DoWork expects an instance of ITokenSource.
    // It can access Token because they're all in the same domain together.
    objectInRemoteAppDomain.DoWork(interAppDomainCancellable);
