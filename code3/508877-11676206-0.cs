    class FileDialogStuff
    {
        static OpenFileDialog dialog = new OpenFileDialog();
    
        public static string GetFile()
        {
            DialogResult result = dialog.ShowDialog();
            //Do stuff
            return dialog.FileName;
        }
    }
