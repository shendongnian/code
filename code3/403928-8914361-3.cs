    public class ThreadOwner
    {
        private bool _done = false;
        public void StartAThread(Form1 form, int min, int max)
        {
            var progress = min;
            new Thread(() =>
                {
                    while (!_done)
                    {
                        form.SetProgress(progress);
                        if (progress++ > max)
                        {
                            progress = min;
                        }
                    }
                    
                }
            ).Start();
        }
        internal void Exit()
        {
            _done = true;
        }
    }
