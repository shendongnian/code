     class Program
     {
         static void Main()
         {
             // Create a FileSystemWatcher to watch the FTP incoming directory for creation of listing file
             using (var watcher = new FileSystemWatcher(@"C:\FTP-Data\Incoming", "*.lst"))
             {
                 // Use the FromEvent operator to setup a subscription to the Created event.           
                 //                                                                                    
                 // The first lambda expression performs the conversion of Action<FileSystemEventArgs> 
                 // to FileSystemEventHandler. The FileSystemEventHandler just calls the handler       
                 // passing the FileSystemEventArgs.                                                   
                 //                                                                                    
                 // The other lambda expressions add and remove the FileSystemEventHandler to and from 
                 // the event.                                                                         
                 var fileCreationObservable = Observable.FromEvent<FileSystemEventHandler, FileSystemEventArgs>(
                                             UseOnlyTheSecondArgument,
                                             fsHandler => watcher.Created += fsHandler,
                                             fsHandler => watcher.Created -= fsHandler);
                 fileCreationObservable.Subscribe(ActionWhenFileIsUploaded);
                 watcher.EnableRaisingEvents = true;
                 Console.WriteLine("Press ENTER to quit the program...\n");
                 Console.ReadLine();
             }
         }
   
         private static void ActionWhenFileIsUploaded(FileSystemEventArgs args)
         {
             Console.WriteLine("{0} was created.", args.FullPath);
   
             // TODO
             // 1. Deduce original file name from the listing file info
             // 2. Consume the data file
             // 3. Remove listing file
         }
   
         private static FileSystemEventHandler UseOnlyTheSecondArgument(Action<FileSystemEventArgs> handler)
         {
             return (object sender, FileSystemEventArgs e) => handler(e);
         }
     }
