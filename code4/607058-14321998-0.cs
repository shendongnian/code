       public ConcurrentQueue<yourType> alarmQueue = new ConcurrentQueue<yourType>();
        System.Timers.Timer timer;
        public QueueManager()
        {
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;
        }
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DeQueueAlarm();
        }
        private void DeQueueAlarm()
        {
            yourType yourtype;
            while (alarmQueue.TryDequeue(out yourtype))
            {
               //dostuff
            }
            
        }
