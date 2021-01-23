    public Form1()
    {
         InitializeComponent();
    }
    
        #region Variables
        Process p;
        #endregion Variables
        
        [...]
        
        void myMethod()
        {
                try
                {
                    p = new Process();
                    p.StartInfo.FileName = "cmd.exe";
                    p.StartInfo.RedirectStandardInput = true;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.UseShellExecute = false;
                    p.Start();
    
                    p.StandardInput.WriteLine("start control"); 
                    p.StandardInput.Flush();
                    p.StandardInput.Close();
                    Console.WriteLine(p.StandardOutput.ReadToEnd());
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
