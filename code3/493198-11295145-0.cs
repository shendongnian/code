        public static void DeleteImage(string filePath, int maxTries = 0) // if maxTries is 0 we will try until success
        {
            if (File.Exists(filePath))
            {
                int tryNumber = 0;
                while (tryNumber++ < maxTries || maxTries == 0)
                {
                    try
                    {
                        File.Delete(filePath);
                        break;
                    }
                    catch (IOException)
                    {
                        // file locked - we must try again
                        // you may want to sleep here for a while
                        // Thread.Sleep(10);
                    }
                }
            }
        }
