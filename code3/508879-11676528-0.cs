    public interface IFileOpener
    {
        public bool PresentFileOpenDialogToUser();
        public string RequestedFilePath { get; }
    }
    public class DefaultFileOpener : IFileOpener
    {
        private string filePath = default(string);
        public bool PresentFileOpenDialogToUser()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                this.filePath = default(string);
                return false;
            }
            else
            {
                this.filePath = ofd.FileName;
                return true;
            }
        }
        public string RequestedFilePath
        {
            get 
            {
                return this.filePath;
            }
        }
    }
    public class FileOpenerFactory
    {
        public static IFileOpener CreateFileOpener()
        {
            return new DefaultFileOpener();
        }
    }
