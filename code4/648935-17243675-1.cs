    public static class TaskExtension {
        public static CustomTaskAwaitable ConfigureScheduler(this Task task, TaskScheduler scheduler) {
            return new CustomTaskAwaitable(task, scheduler);
        }
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
