        public void SendAll(string DirectoryPath)
        {
        
            if (Directory.Exists(DirectoryPath))
                {
                    string[] fileEntries = Directory.GetFiles(DirectoryPath);
                    string[] subdirEntries = Directory.GetDirectories(DirectoryPath);
        
                    foreach (string fileName in fileEntries)
                    {
                        Send(fileName);
            
        }
    
                foreach (string dirName in subdirEntries)
                {
                    SendAll(dirName);
                }
            }
}
