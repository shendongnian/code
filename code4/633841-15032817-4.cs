    //Deadlock
    public class Program
    {
        public static void Main(string[] args)
        {
            WeveGotAProblem p = new WeveGotAProblem();
            p.doThis();//gain a lock on this thread                        
        }        
    }
    class ILockMySelf
    {
        public void doThat()
        {
            //Thread2 waits on Thread1 to release "this"
            lock (this)
            {
                Console.WriteLine("that");
            }
        }
    }
    class WeveGotAProblem
    {
        ILockMySelf anObjectIShouldntUseToLock = new ILockMySelf();
        public void doThis()
        {
            lock (anObjectIShouldntUseToLock)
            {
                Task task = Task.Factory.StartNew(new Action(() => anObjectIShouldntUseToLock.doThat()));
                Task.WaitAll(task);//Thread1 waits on Thread2 to return.  This is important
            }
        }
    }
