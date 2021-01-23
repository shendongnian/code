    public interface ICommandQueue {
         void Add( Command command );
    }
    public class CommandQueue : ICommandQueue {
         private ConcurrentQueue<Command> queue = new ConcurrentQueue<Command>();
         public void Add( Command command ) {
             queue.Enqueue( command );
         }
    }
