    public class MyClass
    {
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
    
        public void doProcess(string filename, string arguments){
        
            using (Process proc = new Process())
            {
                proc.StartInfo.FileName = filename;
                proc.StartInfo.Arguments = arguments;
                proc.Start();
    
                SetForegroundWindow(proc.MainWindowHandle);
            }
        }
    }
