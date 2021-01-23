    public class TriggerReduce //StartNew is fast and returns fast
    {
        private readonly object _lock = new object();
        private readonly int _triggerIntervalMins = 5;
        private DateTime _nextTriggerAt = DateTime.MinValue;
        private bool inTrigger = false;
        public void Execute(object sender, EventArgs e)
        {
            lock (_lock)
            {
                var currentTime = DateTime.Now;
                if (_nextTriggerAt > currentTime)
                    return;
                _nextTriggerAt = currentTime.AddMinutes(_triggerIntervalMins);//runs X mins after last task started running (or longer if task took longer than X mins)
            }
            Task.Factory.StartNew(() =>
            {
                //Trigger reduce which is a long running task
            }, TaskCreationOptions.LongRunning);
        }
    }
    public class TriggerReduce//startNew is a long running function that you want to wait before you recalculate next execution time
    {
        private readonly object _lock = new object();
        private readonly int _triggerIntervalMins = 5;
        private DateTime _nextTriggerAt = DateTime.MinValue;
        private bool inTrigger = false;
        public void Execute(object sender, EventArgs e)
        {
            var currentTime;
            lock (_lock)
            {
                currentTime = DateTime.Now;
                if (inTrigger || (_nextTriggerAt > currentTime))
                    return;
                inTrigger = true;
            }
            Task.Factory.StartNew(() =>
            {
                //Trigger reduce which is a long running task
            }, TaskCreationOptions.LongRunning);
            lock (_lock)
            {
                inTrigger = false;
                _nextTriggerAt = DateTime.Now.AddMinutes(_triggerIntervalMins);//runs X mins after task finishes
                //_nextTriggerAt = currentTime.AddMinutes(_triggerIntervalMins);//runs X mins after last task started running (or longer if task took longer than X mins)
            }
        }
    }
