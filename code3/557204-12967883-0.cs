        public sealed class RunOnceAction
        {
            private readonly Action F;
            private bool hasRun;
            public RunOnceAction(Action f)
            {
                F = f;
            }
            public void run()
            {
                if (hasRun) return;
                F();
                hasRun = true;
            }
        }
