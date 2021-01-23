    private string ReplaceInvalidFolderNameChars(string proposedFolderName_)
    {
        char[] chars = Path.GetInvalidFilenameChars();
        Array.ForEach(chars, c => proposedFolderName_ = proposedFolderName_.Replace(c, '_'));
        return proposedFolderName_;
    }
