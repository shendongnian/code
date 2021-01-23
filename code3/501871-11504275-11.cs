    public ListDirectory (DirectoryInfo dir)
    {
         Output("<li>");    Output(dir.Name);
             if (dir.Directories.Count > 0 || dir.Files.Count > 0) {
                 Output("<ul>");
                 foreach (DirectoryInfo subdir in dir.Directories) {
                     ListDirectory(subdir);
                 }
                 foreach (FileInfo file in dir.Files) {
                     Output("<li>");  Output(file.Name);  Output("</li>");
                 }
                 Output("</ul>");
             }
         Output("</li>");
    }
