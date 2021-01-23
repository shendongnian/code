    using System;
    using Microsoft.Win32;
    using System.Drawing;
    
    namespace Namespace
    {
    public static class DefaultSystemBrowser
    {
        private static bool initialized = false;
        private static string path = null;
        
        public static string Path
        {
            get 
            {
                CheckForErrors();
                return path;
            }
        }
        public static Icon Icon
        {
            get {
                CheckForErrors();
                return Icon.ExtractAssociatedIcon( path );
            }
        }
        public static Bitmap Bitmap
        {
            get
            {
                CheckForErrors();
                return Icon.ExtractAssociatedIcon( path ).ToBitmap();
            }
        }
        private static void CheckForErrors()
        {
            if ( !initialized )
                throw new InvalidOperationException( "You can't use DefaultSystemBrowser class before you call Determine()." );
            if ( ErrorMessage != null )
                throw new InvalidOperationException( "You can't use DefaultSystemBrowser class if call to Determine() resulted in error." );
        }
        /// <summary>
        /// Null if no error occured, error description otherwise.
        /// </summary>
        public static string ErrorMessage
        {
            get;
            private set;
        }
        /// <summary>
        /// Finds out all information about current default browser. You can call this method every time you want to find out default browser.
        /// </summary>
        public static void Determine()
        {
            path = String.Empty;
            initialized = true;
            RegistryKey regKey = null;
            ErrorMessage = null;
            
            try
            {
                //set the registry key we want to open
                regKey = Registry.ClassesRoot.OpenSubKey( "HTTP\\shell\\open\\command", false );
                //get rid of the enclosing quotes
                path = regKey.GetValue( null ).ToString().ToLower().Replace( "" + (char) 34, "" );
                //check to see if the value ends with .exe (this way we can remove any command line arguments)
                if ( !path.EndsWith( "exe" ) )
                    //get rid of all command line arguments (anything after the .exe must go)
                    path = path.Substring( 0, path.LastIndexOf( ".exe" ) + 4 );
                initialized = true;
            }
            catch ( Exception ex )
            {
                ErrorMessage = string.Format( "ERROR: An exception of type: {0} occurred in method: {1} in the following module: {2}", ex.GetType(), ex.TargetSite, typeof( DefaultSystemBrowser ) );
            }
            finally
            {
                //check and see if the key is still open, if so
                //then close it
                if ( regKey != null )
                    regKey.Close();
            }
        }
    }
    }
