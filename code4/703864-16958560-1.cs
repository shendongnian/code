    static void DirDelete(string sDir)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        File.Delete(f);
                    }
                    DirDelete(d);
                    Directory.Delete(d);
                }
                Directory.Delete(sDir);
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }
