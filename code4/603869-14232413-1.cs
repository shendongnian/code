      string bin = "c:\YourBin";
        
        DirectoryInfo oDirectoryInfo = new DirectoryInfo( bin );
        
        //Check the directory exists
        if ( oDirectoryInfo.Exists )
        {
           //Foreach Assembly with dll as the extension
           foreach ( FileInfo oFileInfo in oDirectoryInfo.GetFiles( "*.dll", SearchOption.AllDirectories ) )
           {
        
                            Assembly tempAssembly = null;
    
                            //Before loading the assembly, check all current loaded assemblies in case talready loaded
                            //has already been loaded as a reference to another assembly
                            //Loading the assembly twice can cause major issues
                            foreach ( Assembly loadedAssembly in AppDomain.CurrentDomain.GetAssemblies() )
                            {
                                //Check the assembly is not dynamically generated as we are not interested in these
                                if ( loadedAssembly.ManifestModule.GetType().Namespace != "System.Reflection.Emit" )
                                {
                                    //Get the loaded assembly filename
                                    string sLoadedFilename =
                                        loadedAssembly.CodeBase.Substring( loadedAssembly.CodeBase.LastIndexOf( '/' ) + 1 );
    
                                    //If the filenames match, set the assembly to the one that is already loaded
                                    if ( sLoadedFilename.ToUpper() == oFileInfo.Name.ToUpper() )
                                    {
                                        tempAssembly = loadedAssembly;
                                        break;
                                    }
                                }
                            }
    
                            //If the assembly is not aleady loaded, load it manually
                            if ( tempAssembly == null )
                            {
                                tempAssembly = Assembly.LoadFile( oFileInfo.FullName );
                            }
                            Assembly a = tempAssembly;
           }
        
         }
