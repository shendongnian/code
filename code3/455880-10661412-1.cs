    [DllImport("user32.dll", SetLastError = true)]
    static extern bool SetSystemCursor(IntPtr hcur, uint id);
    const uint OCR_NORMAL = 32512;
    const uint OCR_HAND = 32649;
    const uint OCR_IBEAM = 32513;
            IntPtr hArrow = LoadImage(IntPtr.Zero, "<my custom cursor file>", ImageType.Cursor, width, height, LoadImageFlags.LoadFromFile);
            IntPtr hHand = LoadImage(IntPtr.Zero, "<my custom cursor file>", ImageType.Cursor, width, height, LoadImageFlags.LoadFromFile);
            IntPtr hBeam = LoadImage(IntPtr.Zero, "<my custom cursor file>", ImageType.Cursor, width, height, LoadImageFlags.LoadFromFile);
            RegistryKey myCursors = Registry.CurrentUser.OpenSubKey(defaultCursors);
            string[] keyCursors = myCursors.GetValueNames();
            bool beamFound = false;
            int lastError = 0;
            foreach (string cursorKey in keyCursors)
            {
                RegistryValueKind rvk = myCursors.GetValueKind(cursorKey);
                switch (rvk)
                {
                    case RegistryValueKind.ExpandString:
                        string cursorValue = myCursors.GetValue(cursorKey) as string;
                        if (!String.IsNullOrEmpty(cursorValue))
                        {
                            UserCursors currentSystemCursor = new UserCursors(cursorValue, cursorKey);
                            switch (cursorKey)
                            {
                                case "Arrow":
                                    currentSystemCursor.Changed = SetSystemCursor(hArrow, OCR_NORMAL);
                                    break;
                                case "Hand":
                                    currentSystemCursor.Changed = SetSystemCursor(hHand, OCR_HAND);
                                    if (!currentSystemCursor.Changed)
                                    {
                                        lastError = Marshal.GetLastWin32Error();
                                        Win32Exception ex = new Win32Exception(lastError);
                                    }
                                    break;
                                case "IBeam":
                                    beamFound = true;
                                    currentSystemCursor.Changed = SetSystemCursor(hBeam, OCR_IBEAM);
                                    break;
                                default:
                                    break;
                            }
                            systemCursors.Add(currentSystemCursor);
                        }
                        break;
                    default:
                        break;
                }
            }
            // if a user hasn't customised the IBeam then it doesn't appear in the registry so we still change it
            // and then clear the value to remove it.
            if (!beamFound)
            {
                UserCursors currentSystemCursor = new UserCursors("C:\\Windows\\Cursors\\beam_i.cur", "IBeam");
                currentSystemCursor.Changed = SetSystemCursor(hBeam, OCR_IBEAM);
                systemCursors.Add(currentSystemCursor);
            }
