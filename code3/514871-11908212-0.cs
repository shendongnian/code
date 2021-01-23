    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.tplTestOne();
        }
        public void tplTestOne()
        {
            //-------------------------------------------------
            MyClassHere.onUnobservedTaskException += (object sender, EventException e) =>
            {
                Console.WriteLine(e.Exception.Message); //its fired OK
            };
            TaskScheduler.UnobservedTaskException += (object sender, UnobservedTaskExceptionEventArgs e) =>
            {
                Console.WriteLine(e.Exception.Message); // its not fired, buggy
            };
            //-------------------------------------------------
            CancellationTokenSource source = new CancellationTokenSource();
            Task tz = MyClassHere.CreateHandledTask(
                new TaskScheduled(0, () => {
                    if (!source.IsCancellationRequested)
                    {
                        Console.WriteLine("A-main-task-started");
                    }
                    Thread.Sleep(5000);
                    if (source.IsCancellationRequested)
                    {
                        Console.WriteLine("CancelingMainTask");
                    }
                })
                , new TaskScheduled(3000, () => { Console.WriteLine("okTaskCalled"); }) 
                , null //new TaskScheduled(0, () => { Console.WriteLine("cancelTaskCalled"); })
                , TaskCreationOptions.AttachedToParent
                , source.Token
                , new TaskScheduled(2000, () =>
                {
                    if (!source.IsCancellationRequested)
                    {
                        Console.WriteLine("B-timeout");
                    }
                })
                , new TaskScheduled(1000, () =>
                {
                    if (!source.IsCancellationRequested)
                    {
                        Console.WriteLine("C-timeout");
                    }
                    source.Cancel();
                })
            );
            if(tz != null)
            {
                tz.ContinueWith(t => { Console.WriteLine("END"); });
            }			
    			
    			
    			
            Task tsk_1 = MyClassHere.createHandledTask(() =>
            {
                double x = 1;
                x = (x + 1) / x;
            }, false);
            Task tsk_2 = MyClassHere.createHandledTask(() =>
            {
                double y = 0;
                throw new Exception("forced_divisionbyzerodontthrowanymore_test"); // here -> System.Exception was unhandled by user code
            }, true);
            Task tsk_3 = MyClassHere.createHandledTask(() =>
            {
                double z = 1;
                z = (z + 1) / z;
            }, true);
            Task tsk_4 = MyClassHere.createHandledTask(() =>
            {
                double k = 1;
                k = (k + 1) / k;
            }, true);
            Console.ReadLine();
        }
    }
    
    public class EventException : EventArgs
    {
        public Exception Exception;
        public Task task;
        public EventException(Exception err, Task tsk)
        {
            Exception = err;
            task = tsk;
        }
    }
    public class TaskScheduled
    {
        public int waitTime;
        public Action action;
        public DateTime datestamp;
        public bool isCalled = false;
        public TaskScheduled(int _waitTime, Action _action)
        {
            this.waitTime = _waitTime;
            this.action = _action;
        }
    }
    public static class MyClassHere
    {
        public delegate void UnobservedTaskException(object sender, EventException e);
        public static event UnobservedTaskException onUnobservedTaskException;
        //-------------------------------------------------
        public static void waitForTsk(Task t)
        {
            try
            {
                t.Wait();
            }
            catch (AggregateException ae)
            {
                ae.Handle((err) =>
                {
                    throw err;
                });
            }
        }
        //-------------------------------------------------
        public static void RaiseUnobsrvEvtForEachIfHappens(this Task task)
        {
            task.ContinueWith(t =>
            {
                var aggException = t.Exception.Flatten();
                foreach (var exception in aggException.InnerExceptions)
                {
                    onUnobservedTaskException(task, new EventException(exception, task));
                }
            },
            TaskContinuationOptions.OnlyOnFaulted); // not valid for multi task continuations
        }
        //-------------------------------------------------
        public static Task CreateHandledTask(Action action)
        {
            return CreateHandledTask(action, false);
        }
        public static Task CreateHandledTask(Action action, bool attachToParent)
        {
            Task tsk = null;
            tsk = CreateHandledTask(action, attachToParent, CancellationToken.None);
            return tsk;
        }
        public static Task CreateHandledTask(Action action, bool attachToParent, CancellationToken cancellationToken)
        {
            Task tsk = null;
            TaskCreationOptions atp = TaskCreationOptions.None;
            if (attachToParent) { atp = TaskCreationOptions.AttachedToParent; }
            tsk = CreateHandledTask(action, atp, cancellationToken);
            return tsk;
        }        
        public static Task CreateHandledTask(Action action, TaskCreationOptions tco, CancellationToken cancellationToken)
        {
            Task tsk = null;
            tsk = Task.Factory.StartNew(action, cancellationToken, tco, TaskScheduler.Default);
            tsk.RaiseUnobsrvEvtForEachIfHappens();
            return tsk;
        }
        public static Task CreateHandledTask(TaskScheduled mainTask,
                                             TaskScheduled onSuccessTask,                                              
                                             TaskScheduled onCancelationTask,
                                             TaskCreationOptions tco, 
                                             CancellationToken cancellationToken, 
                                             params TaskScheduled[] timeouts)
        {
            Task tsk = null;
            ManualResetEvent me = new ManualResetEvent(false);
            if (timeouts == null || timeouts.Length < 1 || timeouts[0] == null)
            {
                tsk = CreateHandledTask(mainTask.action, tco, cancellationToken);
                me.Set();
            }
            else
            {
                bool isCancelation = false;
                bool isSuccess = true;
                Task NonBlockCtxTask = CreateHandledTask(() =>
                {
                    tsk = CreateHandledTask(mainTask.action, tco, cancellationToken);
                    me.Set();
                    int qtdt = timeouts.Count(st => st.action != null);
                    CountdownEvent cde_pas = new CountdownEvent(3);
                    CountdownEvent cde_pat = new CountdownEvent(qtdt);
                    Parallel.ForEach<TaskScheduled>(timeouts, (ts) =>
                    {
                        try
                        {
                            bool itsOnTime = tsk.Wait(ts.waitTime, cancellationToken);
                            cde_pat.Signal();
                            if (!itsOnTime)
                            {
                                isSuccess = false;
                                Task tact = CreateHandledTask(ts.action, TaskCreationOptions.None, cancellationToken);
                            }
                        }
                        catch (OperationCanceledException oce)
                        {
                            isSuccess = false;
                            cde_pat.Signal(cde_pat.CurrentCount);
                            isCancelation = true;
                        }
                    });
                    try
                    {
                        isSuccess &= cde_pat.Wait(System.Threading.Timeout.Infinite, cancellationToken) && !isCancelation;
                    }
                    catch (OperationCanceledException oce)
                    {
                        isCancelation = true;
                        isSuccess = false;
                    }
                    finally
                    {
                        cde_pas.Signal();
                    }
                    try
                    {
                        if (isCancelation && onCancelationTask != null)
                        {
                            Thread.Sleep(onCancelationTask.waitTime);
                            Task tcn = CreateHandledTask(onCancelationTask.action);
                        }
                    }
                    catch { }
                    finally {
                        cde_pas.Signal();
                    }
                    try
                    {
                        if (isSuccess && onSuccessTask != null)
                        {
                            Thread.Sleep(onSuccessTask.waitTime);
                            Task tcn = CreateHandledTask(onSuccessTask.action);
                        }
                    }
                    catch { }
                    finally
                    {
                        cde_pas.Signal();
                    }
                    cde_pas.Wait(System.Threading.Timeout.Infinite);
                }, TaskCreationOptions.None, cancellationToken);              
            }
            me.WaitOne();
            return tsk;
        }
        //-------------------------------------------------
    }
  
