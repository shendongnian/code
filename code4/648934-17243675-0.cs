        TaskCompletionSource<object> source = new TaskCompletionSource<object>();
        public async Task Foo() {
            // Force await to schedule the task on the supplied scheduler
            await SomeAsyncTask().ConfigureScheduler(scheduler);
        }
        public Task SomeAsyncTask() { return source.Task; }
