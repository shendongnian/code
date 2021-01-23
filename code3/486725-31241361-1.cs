        /// <summary>Gets the folders associated with a path</summary>
        /// <param name="libname"></param>
        /// <returns>Folder, or List of folders in library, and null if there was an issue</string></returns>
        public List<string> ExpandFolderPath(string foldername)
        {
            List<string> dirList = new List<string> { };
            // If the foldername is an existing directory, just return that
            if ( System.IO.Directory.Exists(foldername) )
            {
                dirList.Add(foldername);
                return dirList;
            }
            // It's not a directory, so check if it's a GUID Library folder
            ICollection<IKnownFolder> allSpecialFolders = Microsoft.WindowsAPICodePack.Shell.KnownFolders.All;
            Regex libguid = new Regex(@"\b([A-F0-9]{8}(?:-[A-F0-9]{4}){3}-[A-F0-9]{12})\b");
            var match = libguid.Match(foldername);
            if ( match == null )
                return null;
            string fpath = "";
            // Iterate over each folder and find the one we want
            foreach ( var folder in allSpecialFolders )
            {
                if ( folder.ParsingName == foldername )
                {
                    // We now have access to the xml path
                    fpath = folder.Path;
                }
            }
            if ( fpath == "" )
                return null;
            var intFolders = GetLibraryInternalFolders(fpath);
            return intFolders.Folders.ToList();
        }
        /// <summary>
        /// Represents an instance of a Windows 7 Library
        /// </summary>
        public class Win7Library
        {
            public Win7Library()
            {
            }
            public string Name { get; set; }
            public string[] Folders { get; set; }
        }
        
        [DllImport("shell32.dll")]
        static extern int SHGetKnownFolderPath( [MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken, out IntPtr pszPath );
        //Handles call to SHGetKnownFolderPath
        public static string getpathKnown( Guid rfid )
        {
            IntPtr pPath;
            if ( SHGetKnownFolderPath(rfid, 0, IntPtr.Zero, out pPath) == 0 )
            {
                string s = System.Runtime.InteropServices.Marshal.PtrToStringUni(pPath);
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(pPath);
                return s;
            }
            else return string.Empty;
        }
        private static string ResolveStandardKnownFolers( string knowID )
        {
            if ( knowID.StartsWith("knownfolder:") )
            {
                return getpathKnown(new Guid(knowID.Substring(12)));
            }
            else
            {
                return knowID;
            }
        }
        private static Win7Library GetLibraryInternalFolders( string libraryXmlPath )
        {
            Win7Library newLibrary = new Win7Library();
            //The Name of a Library is just its file name without the extension
            newLibrary.Name = System.IO.Path.GetFileNameWithoutExtension(libraryXmlPath);
            List<string> folderpaths = new List<string>();
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument(); //* create an xml document object.
            xmlDoc.Load(libraryXmlPath); //* load the library as an xml doc.
            //Grab all the URL tags in the document, 
            //these point toward the folders contained in the library.
            System.Xml.XmlNodeList directories = xmlDoc.GetElementsByTagName("url");
            foreach ( System.Xml.XmlNode x in directories )
            {
                //Special folders use windows7 Know folders GUIDs instead 
                //of full file paths, so we have to resolve them
                folderpaths.Add(ResolveStandardKnownFolers(x.InnerText));
            }
            newLibrary.Folders = folderpaths.ToArray();
            return newLibrary;
        }
