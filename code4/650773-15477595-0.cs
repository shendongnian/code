    public static IEnumerable<string> GetAllFilesRecursively(string inputFolder)
        {
            var queue = new Queue<string>();
            queue.Enqueue(inputFolder);
            while (queue.Count > 0)
            {
                inputFolder = queue.Dequeue();
                try
                {
                    foreach (string subDir in Directory.GetDirectories(inputFolder))
                    {
                        queue.Enqueue(subDir);
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("GetAllFilesRecursively: " + ex);
                }
                string[] files = null;
                try
                {
                    files = Directory.GetFiles(inputFolder);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("GetAllFilesRecursively: " + ex);
                }
                if (files != null)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        yield return files[i];
                    }
                }
            }
        }
