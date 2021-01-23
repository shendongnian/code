    public static class GeoQueryExtensions
    {
        public static Task<T> ExecuteAsync<T>(this Query<T> query)
        {
            var taskSource = new TaskCompletionSource<T>();
     
            EventHandler<QueryCompletedEventArgs<T>> handler = null;
     
            handler = (sender, args) =>
            {
                query.QueryCompleted -= handler;
     
                if (args.Cancelled)
                    taskSource.SetCanceled();
                else if (args.Error != null)
                    taskSource.SetException(args.Error);
                else
                    taskSource.SetResult(args.Result);
            };
     
            query.QueryCompleted += handler;
            query.QueryAsync();
            return taskSource.Task;
        }
    }
