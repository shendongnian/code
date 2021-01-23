    public class SomeService
    {
        private IItemProcessor processor;
		
        public SomeService(IItemProcessor processor)
        {
            this.processor = processor;
        }
        public void Operate(Items items)
        {
            this.processor.Process(items);
        }
    }
    public class ItemProcessor : IItemProcessor
    {
        private IKernel container;
        
        public ItemProcessor(IKernel container)
        {
            this.container = container;
        }
        
        public void Process(Items items)
        {
            Parallel.Foreach(items, item =>
            {
                // request a new IOtherClass again on each thread.			
                var other = this.container.Get<IOtherClass>();
                other.DoWork(item);
            });    
        }
    }
