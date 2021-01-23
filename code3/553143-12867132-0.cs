    using System;
    using System.Reactive;
    using System.Reactive.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApplication140 {
        class Program {
            static void Main() {
                var obj = new MyClass();
                var task = TaskFromEvent<EventArgs>(obj, "Fired");
                new Thread(() => {
                    Thread.Sleep(1000);
                    obj.Fire();
                }).Start();
                task.Wait();
                Console.WriteLine(task.Result.EventArgs);
            }
            public static Task<EventPattern<T>> TaskFromEvent<T>(object target, string eventName) where T : EventArgs {
                var observable = Observable.FromEventPattern<T>(target, eventName);
                var tcs = new TaskCompletionSource<EventPattern<T>>();
                observable.Subscribe(tcs.SetResult);
                return tcs.Task;
            }
        }
        public class MyClass {
            public event EventHandler<EventArgs> Fired;
            public void Fire() {
                var handler = Fired;
                if (handler != null) {
                    handler(this, EventArgs.Empty);
                }
            }
        }
    }
