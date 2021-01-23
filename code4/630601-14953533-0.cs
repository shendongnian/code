        void LaunchTask()
        {
            Task t = Task.Factory.StartNew(() => Run());
            t.ContinueWith( _ => CleanUpTask(t));
        }
        void CleanUpTask(Task task)
        {
            int id = task.Id;
            //cleanup
        }
