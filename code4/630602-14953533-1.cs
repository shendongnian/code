      public void LaunchTask()
        {
            Task<MyType> t = Task.Factory.StartNew(() => Run());
            t.ContinueWith( _ => CleanUpTask(t));
        }
        private void CleanUpTask(Task<MyType> task)
        {
            int id = task.Id;
            MyType t = task.Result;
            //cleanup
        }
        private MyType Run()
        {
            return new MyType {...};
        }
