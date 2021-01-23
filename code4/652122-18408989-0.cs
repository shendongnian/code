    using System;
    using System.Collections.Concurrent;
    using System.ComponentModel;
    using System.IO;
    using System.Threading;
    using NUnit.Framework;
    
    namespace Soundnet.Synchronisation.FileSystemWatcherTests
    {
    
    
      /// <summary>
      /// 
      /// </summary>
      [TestFixture]
      public class Tests
      {
    
        static readonly ConcurrentQueue<Change> ChangesQueue = new ConcurrentQueue<Change>();
        const string Destination = @"c:\Destination";
        const string Source = @"c:\Source";
    
        /// <summary>
        /// Tests this instance.
        /// </summary>
        [Test]
        public void Test()
        {
          var changesBackgroundWorker = new BackgroundWorker();
          changesBackgroundWorker.DoWork += ChangesBackgroundWorkerOnDoWork;
          changesBackgroundWorker.RunWorkerAsync();
          var fileSystemWatcher = new FileSystemWatcher
                                    {
                                      Path = Source,
                                      EnableRaisingEvents = true,
                                      IncludeSubdirectories = true,
                                      NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.LastAccess | NotifyFilters.CreationTime | NotifyFilters.FileName | NotifyFilters.DirectoryName,
                                      InternalBufferSize = 65536
                                    };
          fileSystemWatcher.Created += FileSystemWatcherOnCreated;
          fileSystemWatcher.Deleted += FileSystemWatcherOnDeleted;
          fileSystemWatcher.Renamed += FileSystemWatcherOnRenamed;
          fileSystemWatcher.Error += FileSystemWatcherOnError;
    
          while (true)
            Thread.Sleep(1000000);
        }
    
        /// <summary>
        /// Changeses the background worker configuration document work.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="doWorkEventArgs">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        private static void ChangesBackgroundWorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
          while (true)
          {
            Change change;
            if (ChangesQueue.TryDequeue(out change))
            {
              var backgroundWorker = new BackgroundWorker();
              switch (change.ChangeType)
              {
                case WatcherChangeTypes.Created:
                  backgroundWorker.DoWork += (o, args) =>
                                              {
                                                var fileSystemType = GetFileSystemType(change.FullPath);
    
                                                var newItem = Path.Combine(Destination, change.Name);
                                                while (true)
                                                {
                                                  try
                                                  {
                                                    switch (fileSystemType)
                                                    {
                                                      case FileSystemType.File:
                                                        File.Copy(change.FullPath, newItem, true);
                                                        break;
                                                      case FileSystemType.Directory:
                                                        var directorySecurity =
                                                          Directory.GetAccessControl(change.FullPath);
                                                        Directory.CreateDirectory(newItem, directorySecurity);
                                                        break;
                                                      case FileSystemType.NotExistant:
                                                        break;
                                                    }
                                                    return;
                                                  }
                                                  catch (IOException exception)
                                                  {
                                                    Thread.Sleep(100);
                                                    Console.WriteLine(exception.Message);
                                                  }
                                                }
                                              };
                  break;
                case WatcherChangeTypes.Deleted:
                  backgroundWorker.DoWork += (o, args) =>
                  {
                    var itemToDelete = Path.Combine(Destination, change.Name);
                    var fileSystemType = GetFileSystemType(itemToDelete);
                    switch (fileSystemType)
                    {
                      case FileSystemType.File:
                        File.Delete(itemToDelete);
                        break;
                      case FileSystemType.Directory:
                        Directory.Delete(itemToDelete, true);
                        break;
                    }
                  };
                  break;
                case WatcherChangeTypes.Changed:
                  backgroundWorker.DoWork += (o, args) =>
                  {
                    var fileSystemType = GetFileSystemType(change.FullPath);
                    var newItem = Path.Combine(Destination, change.Name);
                    switch (fileSystemType)
                    {
                      case FileSystemType.File:
                        File.Copy(change.FullPath, newItem, true);
                        break;
                    }
                  };
                  break;
                case WatcherChangeTypes.Renamed:
                  backgroundWorker.DoWork += (o, args) =>
                  {
                    var fileSystemType = GetFileSystemType(change.FullPath);
                    var oldItem = Path.Combine(Destination, change.OldName);
                    var newItem = Path.Combine(Destination, change.Name);
                    switch (fileSystemType)
                    {
                      case FileSystemType.File:
                        if (File.Exists(oldItem))
                          File.Move(oldItem, newItem);
                        break;
                      case FileSystemType.Directory:
                        if (Directory.Exists(oldItem))
                          Directory.Move(oldItem, newItem);
                        break;
                    }
                  };
                  break;
                case WatcherChangeTypes.All:
                  break;
                default:
                  throw new ArgumentOutOfRangeException();
              }
              backgroundWorker.RunWorkerAsync();
            }
          }
        }
    
        /// <summary>
        /// Files the system watcher configuration created.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="fileSystemEventArgs">The <see cref="FileSystemEventArgs"/> instance containing the event data.</param>
        private static void FileSystemWatcherOnCreated(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
          ChangesQueue.Enqueue(new Change
          {
            ChangeType = WatcherChangeTypes.Created,
            FullPath = fileSystemEventArgs.FullPath,
            Name = fileSystemEventArgs.Name
          });
        }
    
        /// <summary>
        /// Files the system watcher configuration deleted.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="fileSystemEventArgs">The <see cref="FileSystemEventArgs"/> instance containing the event data.</param>
        private static void FileSystemWatcherOnDeleted(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
          ChangesQueue.Enqueue(new Change
          {
            ChangeType = WatcherChangeTypes.Deleted,
            FullPath = fileSystemEventArgs.FullPath,
            Name = fileSystemEventArgs.Name
          });
        }
    
        /// <summary>
        /// Files the system watcher configuration error.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="errorEventArgs">The <see cref="ErrorEventArgs"/> instance containing the event data.</param>
        private static void FileSystemWatcherOnError(object sender, ErrorEventArgs errorEventArgs)
        {
          var exception = errorEventArgs.GetException();
          Console.WriteLine(exception.Message);
        }
    
        /// <summary>
        /// Files the system watcher configuration renamed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="fileSystemEventArgs">The <see cref="RenamedEventArgs"/> instance containing the event data.</param>
        private static void FileSystemWatcherOnRenamed(object sender, RenamedEventArgs fileSystemEventArgs)
        {
          ChangesQueue.Enqueue(new Change
          {
            ChangeType = WatcherChangeTypes.Renamed,
            FullPath = fileSystemEventArgs.FullPath,
            Name = fileSystemEventArgs.Name,
            OldFullPath = fileSystemEventArgs.OldFullPath,
            OldName = fileSystemEventArgs.OldName
          });
        }
    
        /// <summary>
        /// Gets the type of the file system.
        /// </summary>
        /// <param name="fullPath">The full path.</param>
        /// <returns></returns>
        private static FileSystemType GetFileSystemType(string fullPath)
        {
          if (Directory.Exists(fullPath))
            return FileSystemType.Directory;
          if (File.Exists(fullPath))
            return FileSystemType.File;
          return FileSystemType.NotExistant;
        }
      }
    
      /// <summary>
      /// Type of file system object
      /// </summary>
      internal enum FileSystemType
      {
        /// <summary>
        /// The file
        /// </summary>
        File,
        /// <summary>
        /// The directory
        /// </summary>
        Directory,
        /// <summary>
        /// The not existant
        /// </summary>
        NotExistant
      }
    
      /// <summary>
      /// Change information
      /// </summary>
      public class Change
      {
        /// <summary>
        /// Gets or sets the type of the change.
        /// </summary>
        /// <value>
        /// The type of the change.
        /// </value>
        public WatcherChangeTypes ChangeType { get; set; }
    
        /// <summary>
        /// Gets or sets the full path.
        /// </summary>
        /// <value>
        /// The full path.
        /// </value>
        public string FullPath { get; set; }
    
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    
        /// <summary>
        /// Gets or sets the old full path.
        /// </summary>
        /// <value>
        /// The old full path.
        /// </value>
        public string OldFullPath { get; set; }
    
        /// <summary>
        /// Gets or sets the old name.
        /// </summary>
        /// <value>
        /// The old name.
        /// </value>
        public string OldName { get; set; }
      }
    }
