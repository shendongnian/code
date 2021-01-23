    using System.Diagnostics;
    
    class Program
    {
        static void Main()
        {
    	// A.
    	// Open specified Photoshop.exe
    	OpenPhotoshop();
        }
    
        /// <summary>
        /// Open photoshop.exe
        /// </summary>
        static void OpenPhotoshop(string f)
        {
    	ProcessStartInfo startInfo = new ProcessStartInfo();
    	startInfo.FileName = "photoshop.exe";
    	startInfo.Arguments = f;
    	Process.Start(startInfo);
        }
    }
