        private bool ClickButton(String window, String button)
        {
            IntPtr errorPopUp;
            IntPtr buttonHandle;
            bool found = false;
            try
            {
                errorPopUp = FindWindow(null, window.Trim());
                found = errorPopUp.ToInt32() != 0;
                if (found)
                {
                    found = false;
                    buttonHandle = FindWindowEx(errorPopUp, IntPtr.Zero, null, button.Trim());
                    found = buttonHandle.ToInt32() != 0;
                    if (found)
                    {
                        SendMessage(buttonHandle, BM_CLICK, IntPtr.Zero, IntPtr.Zero);
                        Trace.WriteLine("Clicked \"" + button + "\" on window named \"" + window + "\"");
                    }
                    else
                    {
                        Debug.WriteLine("Found Window \"" + window + "\" but not its button \"" + button + "\"");
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
            return found;
        }
