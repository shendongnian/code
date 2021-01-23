    class Program
    {
        static void Main(string[] args)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "ConsoleApplication1.exe";
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.RedirectStandardInput = true;
            myProcess.Start();
            StreamWriter myStreamWriter = myProcess.StandardInput;
            var n = 0;
            while (n < 5)
            {
                myStreamWriter.WriteLine("line" + n.ToString());
                n++;
            }
            myStreamWriter.Close();
        }
    }
