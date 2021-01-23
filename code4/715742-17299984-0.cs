    private static FileMonitorManager fileMon = null;
    private static FileProcessingManager processingManager = new FileProcessingManager();
    
    private static void ThreadProc(object param)
    {
        processingManager.RegisterProcessor(new ExcelFileProcessor());
        processingManager.RegisterProcessor(new PdfFileProcessor());
        processingManager.Completed += ProcessingCompletedHandler;
        var procList = new List<string>();
        
        while (true)
        {
            try
            {
                var path = (string)fileMon.FileQueue.Dequeue();
                if (path == null)
                    break;
                    
                bool processThis = false;
                lock(procList)
                {
                    if(!procList.Contains(path))
                    {
                        processThis = true;
                        procList.Add(path);
                    }
                }
                if(processThis)
                {
                    Thread t = new Thread (new ParameterizedThreadStart(processingManager.Process));
                    t.Start (path);
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    
    private static void ProcessingCompletedHandler(bool status, string path)
    {
        if (!status)
        {
            fileMon.FileQueue.Enqueue(path);
            Console.WriteLine("\n\nError on file: " + path);
        }
        else
            Console.WriteLine("\n\nSucces on file: " + path);
    }
