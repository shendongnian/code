    class MyTimerTask: TimerTask
    {
        private Action action;
        public MyTimerTask(Action action)
        {
            this.action = action;
        }
        public override void Run()
        {
            if(action != null)
                action();
        }
    }
