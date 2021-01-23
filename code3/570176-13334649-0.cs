    using System;
    using System.Threading.Tasks;
    using System.IO;
    using System.Diagnostics;
    using System.Threading;
    
    namespace ConsoleApplication4
    {
       class Program
       {
          static void Main(string[] args)
          {
             string fileName = @"C:\Temp\a1.txt";
             int arraySize = 512 * 1024 * 1024;
             var bytes = new byte[arraySize];
             new Random().NextBytes(bytes);
    
              // This prints false, as expected for async call
             var callback = new AsyncCallback(result =>
                                 Console.WriteLine("Completed Synchronously: " + result.CompletedSynchronously));
    
             try
             {
                // Use this method to generate file...
                //WriteFileWithRandomBytes(fileName, arraySize, bytes, callback);
    
                Console.WriteLine("ReadFileAsync invoked at " + DateTimeOffset.Now);
                var task = ReadFileAsync(fileName);
                Console.WriteLine("ReadFileAsync completed at " + DateTimeOffset.Now);
    
                Task.WaitAll(task);
                Console.WriteLine("Wait on a read task completed at " + DateTimeOffset.Now);
             }
             finally
             {
                if (File.Exists(fileName))
                   File.Delete(fileName);
             }
          }
    
          private static void WriteFileWithRandomBytes(string fileName, int arraySize, byte[] bytes, AsyncCallback callback)
          {
             using (var fileStream = new FileStream(fileName,
                FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, 128 * 1024, FileOptions.Asynchronous))
             {
                Console.WriteLine("BeginWrite invoked at " + DateTimeOffset.Now);
                var asyncResult = fileStream.BeginWrite(bytes, 0, arraySize, callback, null);
    
    
                Console.WriteLine("BeginWrite completed at " + DateTimeOffset.Now);
                // completes in 6 seconds or so...  Expecting instantaneous return instead of blocking
    
                // I expect runtime to block here...
                Task.WaitAll(Task.Factory.FromAsync(asyncResult, fileStream.EndWrite));
    
                // or at least when flushing the stream on the following end-curly
             }
          }
    
    
          private static Task<int> ReadFileAsync(string filePath)
          {
             FileInfo fi = new FileInfo(filePath);
             byte[] buffer = new byte[fi.Length];
    
             var file = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None, 64 * 1024, FileOptions.Asynchronous);
             Task<int> task = Task<int>.Factory.FromAsync(file.BeginRead, file.EndRead, buffer, 0, buffer.Length, null);
             return task.ContinueWith(t =>
             {
                file.Close();
                Console.WriteLine("Done ReadFileAsync, read " + t.Result + " bytes.");
                return t.Result;
             });
          }
       }
    }
