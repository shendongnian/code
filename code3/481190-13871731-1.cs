    public static class TimerHelper
    {
        public static void Schedule(this DelayTimer /*or whatever your timer class is*/ timer, Action action, int delay)
        {
            if(timer == null)
                throw new ArgumentNullException("timer"); //null check needed because this method is not really an instance method
            timer.Schedule(new MyTimerTask(action), delay);
        }
    }
