    public partial class Form1
    {
        private void OpenMyFile()
        {
            IFileOpener opener = FileOpenerFactory.CreateFileOpener();
            if (opener.PresentFileOpenDialogToUser())
            {
                //do something with opener.RequestedFilePath;
            }
        }
    }
