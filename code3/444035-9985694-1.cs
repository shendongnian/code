        while (true)
        {
           //starts a new thread
           Thread blueToothThread = new Thread(new ThreadStart(menu.Run));
        }
        
        //the threads method named Run
        public void Run()
        {
            // Perform the bluetooth check here
            Console.WriteLine("You will see this only once every 8 seconds");
            //choose how long thread sleeps here
            Thread.Sleep(8000);
        }
