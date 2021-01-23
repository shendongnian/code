    private void changeText(string searchString, string newString, FileInfo[] listOfFiles)
    {
        foreach (FileInfo tempfi in listOfFiles) {
            string fileToBeEdited = tempfi.FullName; // <== This line was missing
            File.SetAttributes(tempfi.FullName, File.GetAttributes(fileToBeEdited) &
                                                ~FileAttributes.ReadOnly);
            string strFile = System.IO.File.ReadAllText(fileToBeEdited);
            if (strFile.Contains(searchString)) { // <== replaced newString by searchString
                strFile = strFile.Replace(searchString, newString);
                System.IO.File.WriteAllText(fileToBeEdited, strFile);
                myTextBox.Text = "File Changed: " + fileToBeEdited.ToString() +
                                 Environment.NewLine;
            }
        }
    }
