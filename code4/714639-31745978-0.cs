    using System.Runtime.InteropServices;
    class OptimusEnabler
    {
        [DllImport("nvapi.dll")]
        public static extern int NvAPI_Initialize();
    };
