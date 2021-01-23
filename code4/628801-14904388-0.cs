    private void logWatcher_Changed(object sender, FileSystemEventArgs e)
        {
         using (StreamReader readFile = new StreamReader(path))
            {
                string line;
                string[] row;
                while ((line = readFile.ReadLine()) != null)
                {
                   // Here you delete the lines you want or move it to another file, so that your log keeps small. Then save the file. 
                }
            }
        }
