    public static class Extensions
    {
        /// <summary>
        /// Extension method to determine if the current process is executing
        /// code within the Visual Studio designer or not.
        /// </summary>
        public static bool IsVisualStudioDesigner( this Process process )
        {
            return process.MainModule.ModuleName.Contains( "devenv.exe" );
        }
    }
