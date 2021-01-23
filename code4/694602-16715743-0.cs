    using(ShellWindows instances = new ShellWindows())
    {
            //Check if there is an Internet Explorer
            if (instances.Count > 0)
            {
                for (int i = 0; i < instances.count; i++)
                {
                    InternetExplorer ie = instances[i];
                    if (ie.Name == "Windows Internet Explorer")
                    {
                        if (!already_navigated)
                        {
                           // Check here first if IE has an open tab already for you URL
                           // Something like 
                           if(ie.LocationURL != Url)
                           {
                              ie.Navigate(Url, 0x10000);
                           }
                            //Navigate and open in New Tab
                            already_navigated = true;
                            
    
                            //Bring window to front
                            IntPtr hwnd = (IntPtr)ie.HWND;
                            using(WindowHandler.Window w = new WindowHandler.Window(hwnd, "Internet Explorer"))
                            {
                                w.Minimize();
                                w.Restore();
                            }
                        }
                        return;
                    }
                }
            }
    }
