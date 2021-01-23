    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                foreach (var path in Directory.GetFiles(fbd.SelectedPath))
                {
                    Console.WriteLine(path); // full path
                    Console.WriteLine(System.IO.Path.GetFileName(path)); // file name
                }
            }
        }
    }
