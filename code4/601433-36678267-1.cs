    class Program
    {
      static void Main(string[] args)
      {
        using (var watcher = new ObservableFileSystemWatcher(c => { c.Path = @"C:\FolderToWatch\"; c.IncludeSubdirectories = true; }))
        {
          watcher.Created.Select(x => $"{x.Name} was {x.ChangeType}").Subscribe(Console.WriteLine);
          watcher.Changed.Select(x => $"{x.Name} was {x.ChangeType}").Subscribe(Console.WriteLine);
          watcher.Renamed.Select(x => $"{x.OldName} was {x.ChangeType} to {x.Name}").Subscribe(Console.WriteLine);
          watcher.Deleted.Select(x => $"{x.Name} was {x.ChangeType}").Subscribe(Console.WriteLine);
          watcher.Errors.Subscribe(Console.WriteLine);
          watcher.Start();
          Console.ReadLine();
        }
      }
    }
