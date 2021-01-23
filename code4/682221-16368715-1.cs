    using System.Runtime.InteropServices;
    namespace Your.Namespace
    {
        [ComImport]
        [Guid("85788D00-6807-11D0-B810-00C04FD706EC")]
        interface IRunnableTask
        {
            int IsRunning();
            uint Kill(bool fUnused);
            uint Resume();
            uint Run();
            uint Suspend();
        }  
    }
