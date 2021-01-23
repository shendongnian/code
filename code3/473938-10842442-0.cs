    public interface IProcessFactory {
       IProcess Create(int value);
    }
    public class ProcessFactory : IProcessFactory {
        public IProcess Create(int value)
        {
            return this.kernel.Get<IProcess>(new Parameter("value", value, true));
        }
    }
