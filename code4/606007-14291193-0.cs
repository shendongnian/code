        public class Hyperthetical
    {
        public void MyDemoCall(string root)
        {
            Console.WriteLine("-- start --");
            GiveMeADirectoryListingAsIWantIt(root)
            Console.WriteLine("-- end --");
        }
        public void GiveMeADirectoryListingAsIWantIt(string directory)
        {
            Console.WriteLine("Folder '{0}':", directory);
            foreach (var filePath in System.IO.Directory.GetFiles(directory))
            {
                var fileInfo = new FileInfo(filePath);
                Console.WriteLine("File: '{0}', {1}", fileInfo.Name, fileInfo.Length);
            }
            foreach (var subFolders in System.IO.Directory.GetDirectories(directory))
            {
                GiveMeADirectoryListingAsIWantIt(subFolders);
            }
        }
    }
