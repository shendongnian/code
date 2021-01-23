    /// <summary>
    /// Coordinates and wires up the processing pipeline.
    /// </summary>
    public class PingModule : IConsumer<PingStatus>
    {
        private readonly ConcurrentDictionary<IPAddress, PingStatus> _status = new ConcurrentDictionary<IPAddress,PingStatus>();
        private readonly CancellationTokenSource _cancelTokenSource;
        private readonly PingRequestProducerWorkStage _requestProducer;
        private readonly PingWorkStage _pinger;
        private readonly PingReplyProcessingWorkStage _replyProcessor;
        public PingModule(IProvider<IPAddress> addressProvider)
        {
            _cancelTokenSource = new CancellationTokenSource();
            
            _requestProducer = new PingRequestProducerWorkStage(1, addressProvider, NextRequestFor, _cancelTokenSource.Token);
            _pinger = new PingWorkStage(4, 10 * 2, _cancelTokenSource.Token);
            _replyProcessor = new PingReplyProcessingWorkStage(2, 10 * 2, _cancelTokenSource.Token);
            // connect the pipeline.
            _requestProducer.ConnectTo(_pinger);
            _pinger.ConnectTo(_replyProcessor);
            _replyProcessor.ConnectTo(this);
        }
        private PingRequest NextRequestFor(IPAddress address)
        {
            PingStatus curStatus;
            if (!_status.TryGetValue(address, out curStatus))
                return new PingRequest(address, IPStatus.Success, TimeSpan.FromMilliseconds(120));
            if (curStatus.LastResult.TimedOut)
            {
                var newTimeOut = TimeSpan.FromTicks(curStatus.LastResult.TimedOutAfter.Ticks * 2);
                return new PingRequest(address, IPStatus.TimedOut, newTimeOut);
            }
            else
            {
                var newTimeOut = TimeSpan.FromTicks(curStatus.AverageRoundtripTime + 4 * curStatus.RoundTripStandardDeviation);
                return new PingRequest(address, IPStatus.Success, newTimeOut);
            }
        }
        // ...
    }
