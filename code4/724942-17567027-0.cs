    class Game1
    {
        delegate void result(string str);
        public void threadStart(object obj)
        {
            string result = readInput()
            Game1 game = (Game1)obj;
            game.r.BeginInvoke(result, null, null);
        }
        result r;
        public void test(string str)
        {
            //Back on main thread, with result from polled getResult
            string result = str;
        }
        public void start()
        {
            r = test;
            System.Threading.Thread t = new System.Threading.Thread(threadStart);
            t.Start(this);
        }
    }
