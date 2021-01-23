    public int OnShellPropertyChange(int propid, object propValue)
        {
          // --- We handle the event if zombie state changesfrom true to false
            if ((int)__VSSPROPID.VSSPROPID_Zombie == propid)
            {
                if ((bool)propValue == false)
                {
                    // --- Show the commandbar
                    EnvDTE80.DTE2 dte = GetService(typeof(DTE)) as DTE2;
                    CommandBar cb = ((dte.CommandBars as CommandBars)["YourCommandBar"] as CommandBar);
                    foreach (CommandBarControl cbc in cb.Controls)
                    {
                        if (cbc.Caption == "YourCaption")
                        {
                            CommandBarButton btn = (CommandBarButton)cbc;
                            btn.BeginGroup = true; // HERE WE ADD NEW GROUP - means add separator
                        }
                    }
                }
                // --- Unsubscribe from events
                var shellService = GetService(typeof(SVsShell)) as IVsShell;
                if (shellService != null)
                {
                    ErrorHandler.ThrowOnFailure(shellService.UnadviseShellPropertyChanges(_EventSinkCookie));
                }
                _EventSinkCookie = 0;
            }
            return VSConstants.S_OK;
        }
