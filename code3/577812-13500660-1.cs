    namespace Company.Utilities.File
    {
        public class File
        {
            public File(string filename)
            {
               Filename = filename;
            }
            public string Filename { get; private set; }
            public void Process()
            {
                // Some code to process the file.
            }
            public static void ProcessFile(string filename)
            {
                File file = new File(filename);
                file.Process();
            }
        }
    }
