                    //If the plugin assembly is not aleady loaded, load it manually
                    if ( PluginAssembly == null )
                    {
                        PluginAssembly = Assembly.LoadFile( oFileInfo.FullName );
                    }
                    if ( PluginAssembly != null )
                    {
                        //Step through each module
                        foreach ( Module oModule in PluginAssembly.GetModules() )
                        {
                            //step through the types in each module
                            foreach ( Type oModuleType in oModule.GetTypes() )
                            {
                                foreach ( Type oInterfaceType in oModuleType.GetInterfaces() )
                                {
                                    if ( oInterfaceType.Name == "IWAPAddon" )
                                    {
                                        this.Addons.Add( oModuleType );
                                    }
                                }
                            }
                        }
                    }
               
