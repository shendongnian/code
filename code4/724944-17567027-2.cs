    class Game1
    {
        //We declare a queue, which is like an array that we can extract and enter data easily in a FIFO (first in, first out) style list.
        Queue<string> q = new Queue<string>();
        public void threadStart(object obj)
        {
            //We get the result of your funtion, while our main function is still looping and waiting.
            string result = readInput()
            //We tell C# that the parameter we passed in, is in fact the Game1 class passed from "t.Start"
            Game1 game = (Game1)obj;
            //This puts our "result" into the queue.
            game.q.Enqueue(result);
        }
        public void start()
        {
            //Declares a new thread, which will run "threadStart" function.
            System.Threading.Thread t = new System.Threading.Thread(threadStart);
            //We start the other thread (that will run in parallel) and pass "this" as the parameter.
            t.Start(this);
            //We loop over and over, sleeping, whilst the other function runs at the same time. This is called "multi- threading"
            while (q.Count == 0)
            {
                System.Threading.Thread.Sleep(10);
            }
            //This gets the last-entered (oldest) value from the queue q.
            string result = q.Deque();
        }
    }
