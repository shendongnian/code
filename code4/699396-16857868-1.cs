    public class Loader : ILoader
    {
        private IItemAdder _itemAdder;
        public Loader(IItemAdder itemAdder)
        {
            _itemAdder = itemAdder;
        }
        public void Execute()
        {
            // use injected item adder to do work
            _itemAdder.Add();
        }       
    }
    public interface ILoader
    {
        void Execute();
    }
