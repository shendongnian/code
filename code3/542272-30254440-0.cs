    class Program
    {
        const int timerSeconds = 5, actionMinSeconds = 1, actionMaxSeconds = 7;
        static Random _rnd = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to interrupt timer and exit...");
            Console.WriteLine();
            CancellationTokenSource cancelSource = new CancellationTokenSource();
            new Thread(() => CancelOnInput(cancelSource)).Start();
            Console.WriteLine(
                "Starting at {0:HH:mm:ss.f}, timer interval is {1} seconds",
                DateTime.Now, timerSeconds);
            Console.WriteLine();
            Console.WriteLine();
            // NOTE: the call to Wait() is for the purpose of this
            // specific demonstration in a console program. One does
            // not normally use a blocking wait like this for asynchronous
            // operations.
            // Specify the specific implementation to test by providing the method
            // name as the second argument.
            RunTimer(cancelSource.Token, M1).Wait();
        }
        static async Task RunTimer(
            CancellationToken cancelToken, Func<Action, TimeSpan, Task> timerMethod)
        {
            Console.WriteLine("Testing method {0}()", timerMethod.Method.Name);
            Console.WriteLine();
            try
            {
                await timerMethod(() =>
                {
                    cancelToken.ThrowIfCancellationRequested();
                    DummyAction();
                }, TimeSpan.FromSeconds(timerSeconds));
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine();
                Console.WriteLine("Operation cancelled");
            }
        }
        static void CancelOnInput(CancellationTokenSource cancelSource)
        {
            Console.ReadKey();
            cancelSource.Cancel();
        }
        static void DummyAction()
        {
            int duration = _rnd.Next(actionMinSeconds, actionMaxSeconds + 1);
            Console.WriteLine("dummy action: {0} seconds", duration);
            Console.Write("    start: {0:HH:mm:ss.f}", DateTime.Now);
            Thread.Sleep(TimeSpan.FromSeconds(duration));
            Console.WriteLine(" - end: {0:HH:mm:ss.f}", DateTime.Now);
        }
        static async Task M1(Action taskAction, TimeSpan timer)
        {
            // Most basic: always wait specified duration between
            // each execution of taskAction
            while (true)
            {
                await Task.Delay(timer);
                await Task.Run(() => taskAction());
            }
        }
        static async Task M2(Action taskAction, TimeSpan timer)
        {
            // Simple: wait for specified interval, minus the duration of
            // the execution of taskAction. Run taskAction immediately if
            // the previous execution too longer than timer.
            TimeSpan remainingDelay = timer;
            while (true)
            {
                if (remainingDelay > TimeSpan.Zero)
                {
                    await Task.Delay(remainingDelay);
                }
                Stopwatch sw = Stopwatch.StartNew();
                await Task.Run(() => taskAction());
                remainingDelay = timer - sw.Elapsed;
            }
        }
        static async Task M3a(Action taskAction, TimeSpan timer)
        {
            // More complicated: only start action on time intervals that
            // are multiples of the specified timer interval. If execution
            // of taskAction takes longer than the specified timer interval,
            // wait until next multiple.
            // NOTE: this implementation may drift over time relative to the
            // initial start time, as it considers only the time for the executed
            // action and there is a small amount of overhead in the loop. See
            // M3b() for an implementation that always executes on multiples of
            // the interval relative to the original start time.
            TimeSpan remainingDelay = timer;
            while (true)
            {
                await Task.Delay(remainingDelay);
                Stopwatch sw = Stopwatch.StartNew();
                await Task.Run(() => taskAction());
                long remainder = sw.Elapsed.Ticks % timer.Ticks;
                remainingDelay = TimeSpan.FromTicks(timer.Ticks - remainder);
            }
        }
        static async Task M3b(Action taskAction, TimeSpan timer)
        {
            // More complicated: only start action on time intervals that
            // are multiples of the specified timer interval. If execution
            // of taskAction takes longer than the specified timer interval,
            // wait until next multiple.
            // NOTE: this implementation computes the intervals based on the
            // original start time of the loop, and thus will not drift over
            // time (not counting any drift that exists in the computer's clock
            // itself).
            TimeSpan remainingDelay = timer;
            Stopwatch swTotal = Stopwatch.StartNew();
            while (true)
            {
                await Task.Delay(remainingDelay);
                await Task.Run(() => taskAction());
                long remainder = swTotal.Elapsed.Ticks % timer.Ticks;
                remainingDelay = TimeSpan.FromTicks(timer.Ticks - remainder);
            }
        }
        static async Task M4(Action taskAction, TimeSpan timer)
        {
            // More complicated: this implementation is very different from
            // the others, in that while each execution of the task action
            // is serialized, they are effectively queued. In all of the others,
            // if the task is executing when a timer tick would have happened,
            // the execution for that tick is simply ignored. But here, each time
            // the timer would have ticked, the task action will be executed.
            //
            // If the task action takes longer than the timer for an extended
            // period of time, it will repeatedly execute. If and when it
            // "catches up" (which it can do only if it then eventually
            // executes more quickly than the timer period for some number
            // of iterations), it reverts to the "execute on a fixed
            // interval" behavior.
            TimeSpan nextTick = timer;
            Stopwatch swTotal = Stopwatch.StartNew();
            while (true)
            {
                TimeSpan remainingDelay = nextTick - swTotal.Elapsed;
                if (remainingDelay > TimeSpan.Zero)
                {
                    await Task.Delay(remainingDelay);
                }
                await Task.Run(() => taskAction());
                nextTick += timer;
            }
        }
    }
