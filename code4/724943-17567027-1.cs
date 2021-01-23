    class Game1
    {
        public void threadStart(object obj)
        {
            string result = readInput()
            Game1 game = (Game1)obj;
            game.q.Enqueue(result);
        }
        Queue<string> q = new Queue<string>();
        public void start()
        {
            System.Threading.Thread t = new System.Threading.Thread(threadStart);
            t.Start(this);
            while (q.Count == 0)
            {
                System.Threading.Thread.Sleep(10);
            }
            string result = q.Deque();
        }
    }
