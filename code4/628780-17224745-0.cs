        public static void RunAsync(this Task task)
        {
            if (task.Status == TaskStatus.Created)
                task.Start();
        }
