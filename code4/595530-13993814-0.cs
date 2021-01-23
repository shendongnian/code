        private void changeText(string searchString, string newString, FileInfo[] listOfFiles)
    {
        foreach (FileInfo tempfi in listOfFiles)//Foreach File
        {
            File.SetAttributes(fileToBeEdited, File.GetAttributes(fileToBeEdited) & ~FileAttributes.ReadOnly); //Remove ReadOnly Property
            string strFile = System.IO.File.ReadAllText(fileToBeEdited); //Reads In Text File
            if(strFile.Contains(newString))//If the replacement string is contained in the text file
            {
                fileToBeEdited = fileToBeEdited.Replace(searchString,newString); // make the changes
                System.IO.File.WriteAllText(fileToBeEdited, strFile); //Write changes to File
                myTextBox.Text = "File Changed: " + fileTobeEdited.ToString() + Environment.NewLine; //Notify User
            }
        }
    }
