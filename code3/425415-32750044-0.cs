    using System.Windows.Forms;
    using System.Diagnostics;
    
    ...
    
    #if DEBUG 
    int processId = Process.GetCurrentProcess().Id;
    string message = string.Format("Please attach the debugger (elevated on Vista or Win 7) to process [{0}].", processId);
    MessageBox.Show(message, "Debug");
    #endif
    
    ....
