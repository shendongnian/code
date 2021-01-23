    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    
    namespace Example {
        class Program {
            static TaskCompletionSource<object> source = new TaskCompletionSource<object>();
            static TaskScheduler scheduler = new CustomTaskScheduler();
    
            static void Main(string[] args) {
                Console.WriteLine("Main Started");
                var task = Foo();
                Console.WriteLine("Main Continue ");
                // Continue Foo() using CustomTaskScheduler
                source.SetResult(null);
                Console.WriteLine("Main Finished");
            }
    
            public static async Task Foo() {
                Console.WriteLine("Foo Started");
                // Force await to schedule the task on the supplied scheduler
                await SomeAsyncTask().ConfigureScheduler(scheduler);
                Console.WriteLine("Foo Finished");
            }
    
            public static Task SomeAsyncTask() { return source.Task; }
        }
    
        public struct CustomTaskAwaitable {
            CustomTaskAwaiter awaitable;
    
            public CustomTaskAwaitable(Task task, TaskScheduler scheduler) {
                awaitable = new CustomTaskAwaiter(task, scheduler);
            }
    
            public CustomTaskAwaiter GetAwaiter() { return awaitable; }
    
            public struct CustomTaskAwaiter : INotifyCompletion {
                Task task;
                TaskScheduler scheduler;
    
                public CustomTaskAwaiter(Task task, TaskScheduler scheduler) {
                    this.task = task;
                    this.scheduler = scheduler;
                }
    
                public void OnCompleted(Action continuation) {
                    // ContinueWith sets the scheduler to use for the continuation action
                    task.ContinueWith(x => continuation(), scheduler);
                }
    
                public bool IsCompleted { get { return task.IsCompleted; } }
                public void GetResult() { }
            }
        }
    
        public static class TaskExtension {
            public static CustomTaskAwaitable ConfigureScheduler(this Task task, TaskScheduler scheduler) {
                return new CustomTaskAwaitable(task, scheduler);
            }
        }
    
        public class CustomTaskScheduler : TaskScheduler {
            protected override IEnumerable<Task> GetScheduledTasks() { yield break; }
            protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued) { return false; }
            protected override void QueueTask(Task task) {
                TryExecuteTask(task);
            }
        }
    }
