    internal class Program
        {
            private static readonly object listLockObject = new object();
            private  static readonly IList<string> lstFilesFound = new List<string>();
            private static readonly TxtFile txtFile = new TxtFile("Some search pattern");
            private static string sDir = "Something";
    
    
            public static void Main()
            {
                Parallel.ForEach(Directory.GetDirectories(sDir), GetMatchingFolderAndDoSomething);
            }
    
            private static void GetMatchingFolderAndDoSomething(string directory)
            {
                //This too can be parallelized.
                foreach (string f in Directory.GetFiles(directory, txtFile.Text))
                    {
                        lock (listLockObject)
                        {
                            lstFilesFound.Add(f);
                        }
                    }
    
                DirSearch(directory);
            }
    
            //Make this thread safe.
            private static void DirSearch(string s)
            {
            }
    
            public class TxtFile
            {
                public TxtFile(string text)
                {
                    Text = text;
                }
    
                public string Text { get; private set; }
            }
        }
