    internal class FileParser:ImageFileParser
    {
        internal event EventHandler<ProgressChangedEventArgs> ProgressChanged;
        ImageFileParser.GenerateCmds()
        {
            percentage=change;    //0 to 100
            OnProgressChanged(percentage);
            //long time operation
        }
        internal protected void OnProgressChanged(int percentage)
        {
            var p = ProgressChanged;
            if(p != null)
            {
                p(this, new ProgressChangedEventArgs(percentage));
            }
        }
    }
