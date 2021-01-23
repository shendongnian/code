    public static class FileUtils
    {
        public static IObservable<FileSystemEventArgs> ChangedObservable(string path)
        {
            if (path == null)
                return Observable.Never<FileSystemEventArgs>();
            return Observable.Using(() => new FileWatcher(path), watcher => watcher.Changed);
        }
        public static Task DeleteDirectoryAsync(string path, bool recurse)
        {
            var task = new TaskCompletionSource<Unit>();
            if (Directory.Exists(path))
            {
                ChangedObservable(path)
                    .Where(f => f.ChangeType == WatcherChangeTypes.Deleted)
                    .Take(1)
                    .Subscribe(v => task.SetResult(Unit.Default));
                Directory.Delete(path, recurse);
            }
            else
            {
                task.SetResult(Unit.Default);
            }
            return task.Task;
        }
    }
