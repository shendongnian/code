	using System;
	using System.IO;
	using System.Reactive;
	using System.Reactive.Linq;
	using System.Reactive.Subjects;
	using System.Threading.Tasks;
	
	namespace Utils
	{
	    internal class FileWatcher : IDisposable
	    {
	        readonly FileSystemWatcher _Watcher;
	
	        public Subject<FileSystemEventArgs> Changed = new Subject<FileSystemEventArgs>();
	
	        public FileWatcher( string file )
	        {
	            // Create a new FileSystemWatcher and set its properties.
	            _Watcher = new FileSystemWatcher
	                       {
	                           Path = Path.GetDirectoryName(file),
	                           NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
	                                          | NotifyFilters.FileName | NotifyFilters.DirectoryName,
	                           Filter =Path.GetFileName(file) 
	                       };
	
	            // Add event handlers.
	            _Watcher.Changed += OnChanged;
	            _Watcher.Created += OnChanged;
	            _Watcher.Deleted += OnChanged;
	            _Watcher.Renamed += OnChanged;
	
	            // Begin watching.
	            _Watcher.EnableRaisingEvents = true;
	        }
	
	        // Define the event handlers.
	        private void OnChanged( object source, FileSystemEventArgs e )
	        {
	            Changed.OnNext(e);
	        }
	
	
	        public void Dispose()
	        {
	            _Watcher.Dispose();
	        }
	    }
	}
    
