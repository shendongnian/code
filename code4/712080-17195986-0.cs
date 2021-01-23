        Task.Factory.StartNew(() =>
            {
                try
                {
                    var path = (string) _this.FileQueue.Dequeue();
                    if (path == null)
                        break;
                    bool b = processingManager.Process(path);
                    if (!b)
                    {
                        _this.FileQueue.Enqueue(path);
                        Console.WriteLine("\n\nError on file: " + path);
                    }
                    else
                        Console.WriteLine("\n\nSucces on file: " + path);
                }
                catch (System.Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });
