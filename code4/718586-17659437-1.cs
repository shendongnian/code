    public class RequestRouter : IConsumer<PingRequest>
    {
        private readonly Func<PingRequest, IConsumer<PingRequest>> _selector;
        public RequestRouter(Func<PingRequest, IConsumer<PingRequest>> selector)
        {
            this._selector = selector;
        }
        public void Consume(PingRequest work)
        {
            _selector(work).Consume(work);
        }
        public void Consume(PingRequest work, CancellationToken cancelToken)
        {
            _selector(work).Consume(work, cancelToken);
        }
    }
    public class PingModule : IConsumer<PingStatus>
    {
        // ...
        public PingModule(IProvider<IPAddress> addressProvider)
        {
            _cancelTokenSource = new CancellationTokenSource();
            
            _requestProducer = new PingRequestProducerWorkStage(1, addressProvider, NextRequestFor, _cancelTokenSource.Token);
            _disconnectedPinger = new PingWorkStage(2, 10 * 2, _cancelTokenSource.Token);
            _slowAddressesPinger = new PingWorkStage(2, 10 * 2, _cancelTokenSource.Token);
            _normalPinger = new PingWorkStage(3, 10 * 2, _cancelTokenSource.Token);
            _requestRouter = new RequestRouter(RoutePingRequest);
            _replyProcessor = new PingReplyProcessingWorkStage(2, 10 * 2, _cancelTokenSource.Token);
            // connect the pipeline
            _requestProducer.ConnectTo(_requestRouter);
            _disconnectedPinger.ConnectTo(_replyProcessor);
            _slowAddressesPinger.ConnectTo(_replyProcessor);
            _normalPinger.ConnectTo(_replyProcessor);
            _replyProcessor.ConnectTo(this);
        }
        private IConsumer<PingRequest> RoutePingRequest(PingRequest request)
        {
            if (request.LastKnownStatus != IPStatus.Success)
                return _disconnectedPinger;
            if (request.PingTimeOut > TimeSpan.FromMilliseconds(500))
                return _slowAddressesPinger;
            return _normalPinger;
        }
        // ...
    } 
