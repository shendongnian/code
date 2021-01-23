    public class SimpleWorkQueue
    {
        private Task _main = null;
        public void AddTask(Action task)
        {
            if (_main == null)
            {
                _main = new Task(task);
                _main.Start();
            }
            else
            {
                Action<Task> next = (t) => task();
                _main = _main.ContinueWith(next);
            }
        }
    }
