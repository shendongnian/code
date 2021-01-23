    /// <summary>
        /// Checks if application window open.
        /// </summary>
        /// <returns></returns>
        private static bool IfApplicationWindowOpen(string windowName)
        {
            List<string> collection = new List<string>();
            user32.EnumDelegate filter = delegate(IntPtr hWnd, int lParam)
            {
                StringBuilder strbTitle = new StringBuilder(255);
                int nLength = user32.GetWindowText(hWnd, strbTitle, strbTitle.Capacity + 1);
                string strTitle = strbTitle.ToString();
                if (user32.IsWindowVisible(hWnd) && string.IsNullOrEmpty(strTitle) == false)
                {
                    collection.Add(strTitle);
                }
                return true;
            };
            if (user32.EnumDesktopWindows(IntPtr.Zero, filter, IntPtr.Zero))
            {
                foreach (string item in collection)
                {
                    if (item.ToString().Equals(windowName))
                    {
                        return true;
                        break;
                    }
                }
            }
            return false;
        }
