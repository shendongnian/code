        public void DirSearch(string sDir)
        {
            try
            {
                foreach (string item in extensions)
                {
                    string[] files = Directory.GetFiles(sDir, item, SearchOption.AllDirectories);
                    foreach (var file in files)
                    {
                        Console.WriteLine(file);
                    }
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }
