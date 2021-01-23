    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace UploadLargeBlob
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<ChunkInformation> chunksToUpload = new List<ChunkInformation>();
                CreateChunkCollection("MyVeryLargeFile", 2*1024*1024);
                int numberOfParallelThreads = 8;
                do
                {
                    var chunksToProcess = chunksToUpload.Where(c => c.Status == ChunkStatus.NotStarted || c.Status == ChunkStatus.Failed).Take(numberOfParallelThreads);
                    if (chunksToProcess.Count() == 0)
                    {
                        break;
                    }
                    List<Task> tasks = new List<Task>();
                    try
                    {
                        foreach (var chunk in chunksToProcess)
                        {
                            tasks.Add(Task.Factory.StartNew(() =>
                                {
                                    DoUpload(chunk);
                                }, chunk));
                        }
                        Task.WaitAll(tasks.ToArray());
                    }
                    catch (AggregateException excep)
                    {
                        foreach (var task in tasks)
                        {
                            if (task.Exception != null)
                            {
                                ChunkInformation chunk = task.AsyncState as ChunkInformation;
                                chunk.Status = ChunkStatus.Failed;
                                //Now serialize the data.
                            }
                        }
                    }
                }
                while (true);
            }
    
            static void DoUpload(ChunkInformation chunk)
            {
                //Do the actual upload
    
                //Update chunk status once chunk is uploaded
                chunk.Status = ChunkStatus.Successful;
    
                //Serialize the data.
            }
    
            static void CreateChunkCollection(string fileName, int chunkSize)
            {
            }
        }
    
        public class ChunkInformation
        {
            public string Id
            {
                get;
                set;
            }
    
            public ChunkStatus Status
            {
                get;
                set;
            }
        }
    
        public enum ChunkStatus
        {
            NotStarted,
            Successful,
            Failed
        }
    }
