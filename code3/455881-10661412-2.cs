        ~MainWindow()
        {
            int lastError = 0;
            bool changed = false;
            foreach (UserCursors savedCursor in systemCursors)
            {
                if (savedCursor.Changed)
                {
                    switch (savedCursor.regKeyName)
                    {
                        case "Arrow":
                            changed = SetSystemCursor(savedCursor.hInst, OCR_NORMAL);
                            if (!changed)
                            {
                                lastError = Marshal.GetLastWin32Error();
                                Win32Exception ex = new Win32Exception(lastError);
                            }
                            break;
                        case "Hand":
                            changed = SetSystemCursor(savedCursor.hInst, OCR_HAND);
                            if (!changed)
                            {
                                lastError = Marshal.GetLastWin32Error();
                                Win32Exception ex = new Win32Exception(lastError);
                            }
                            break;
                        case "IBeam":
                            changed = SetSystemCursor(savedCursor.hInst, OCR_IBEAM);
                            if (!changed)
                            {
                                lastError = Marshal.GetLastWin32Error();
                                Win32Exception ex = new Win32Exception(lastError);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
