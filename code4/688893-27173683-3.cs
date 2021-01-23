    public abstract class AbstractMultiplyBlock<TInput, TOutput>
        : IPropagatorBlock<TInput, TOutput>, IReceivableSourceBlock<TOutput>
    {
        private readonly TransformBlock<TInput, TOutput> innerBlock;
        protected AbstractMultiplyBlock(TransformBlock<TInput, TOutput> innerBlock)
        {
            this.innerBlock = innerBlock;
        }
        public DataflowMessageStatus OfferMessage(DataflowMessageHeader messageHeader, TInput messageValue, ISourceBlock<TInput> source,
            bool consumeToAccept)
        {
            return ((ITargetBlock<TInput>)innerBlock).OfferMessage(messageHeader, messageValue, source, consumeToAccept);
        }
        public void Complete()
        {
            innerBlock.Complete();
        }
        public void Fault(Exception exception)
        {
            ((IDataflowBlock)innerBlock).Fault(exception);
        }
        public Task Completion
        {
            get { return innerBlock.Completion; }
        }
        public IDisposable LinkTo(ITargetBlock<TOutput> target, DataflowLinkOptions linkOptions)
        {
            return innerBlock.LinkTo(target, linkOptions);
        }
        public TOutput ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target, out bool messageConsumed)
        {
            return ((ISourceBlock<TOutput>)innerBlock).ConsumeMessage(messageHeader, target, out messageConsumed);
        }
        public bool ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target)
        {
            return ((ISourceBlock<TOutput>)innerBlock).ReserveMessage(messageHeader, target);
        }
        public void ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target)
        {
            ((ISourceBlock<TOutput>)innerBlock).ReleaseReservation(messageHeader, target);
        }
        public bool TryReceive(Predicate<TOutput> filter, out TOutput item)
        {
            return innerBlock.TryReceive(filter, out item);
        }
        public bool TryReceiveAll(out IList<TOutput> items)
        {
            return innerBlock.TryReceiveAll(out items);
        }
    }
