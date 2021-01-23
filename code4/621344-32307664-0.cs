            logger.Info(GlobalModulename + "@ ScreenList::looking for screen:"+Name);
            if ((Name == "Primary"))
            {
                bool ExpectedParameter = true;
                foreach (var screen in Screen.AllScreens)
                {
                    // For each screen, add the screen properties to a list box.
                    logger.Info(GlobalModulename + "@ ScreenList::("+screen.DeviceName.ToString()+")Primary Screen: " + screen.Primary.ToString());
                    if (screen.Primary==ExpectedParameter)
                    {
                        return screen;
                    }
                }
            }
            if ((Name == "Secondary"))
            {
                bool ExpectedParameter = false;
                foreach (var screen in Screen.AllScreens)
                {
                    // For each screen, add the screen properties to a list box.
                    logger.Info(GlobalModulename + "@ ScreenList::(" + screen.DeviceName.ToString() + ")Primary Screen: " + screen.Primary.ToString());
                    if (screen.Primary == ExpectedParameter)
                    {
                        return screen;
                    }
                }
            }
            // konkretni jmeno obrazovky tak jak je to v systemu
            try
            {
                foreach (var screen in Screen.AllScreens)
                {
                    // For each screen, add the screen properties to a list box.
                    logger.Info("UEFA_Core @ ScreenList::Device Name: " + screen.DeviceName);
                    logger.Info("UEFA_Core @ ScreenList::Bounds: " + screen.Bounds.ToString());
                    logger.Info("UEFA_Core @ ScreenList::Type: " + screen.GetType().ToString());
                    logger.Info("UEFA_Core @ ScreenList::Working Area: " + screen.WorkingArea.ToString());
                    logger.Info("UEFA_Core @ ScreenList::Primary Screen: " + screen.Primary.ToString());
                    if (screen.DeviceName == Name) return screen;
                }
            }
            catch { }
            // podobne jmeno obrazovky tak jak je to v systemu
            try
            {
                foreach (var screen in Screen.AllScreens)
                {
                    // For each screen, add the screen properties to a list box.
                    logger.Info("UEFA_Core @ ScreenList::Device Name: " + screen.DeviceName);
                    logger.Info("UEFA_Core @ ScreenList::Bounds: " + screen.Bounds.ToString());
                    logger.Info("UEFA_Core @ ScreenList::Type: " + screen.GetType().ToString());
                    logger.Info("UEFA_Core @ ScreenList::Working Area: " + screen.WorkingArea.ToString());
                    logger.Info("UEFA_Core @ ScreenList::Primary Screen: " + screen.Primary.ToString());
                    if (screen.DeviceName.Contains(Name)) return screen;
                }
            }
            catch { }
            logger.Info("UEFA_Core @ ScreenList::No screen found by name");
            return Screen.PrimaryScreen;
        }
