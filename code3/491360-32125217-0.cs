            IWebDriver popup = null;
            string mainWindow = driver.CurrentWindowHandle;
            bool foundPopupTitle = false;
            foreach (string handle in driver.WindowHandles)
            {
                popup = driver.SwitchTo().Window(handle);
                if (popup.Title.Contains(title))
                {
                    foundPopupTitle = true;
                    break;
                }
            }
            if (foundPopupTitle)
            {
                popup.Close();
            }
            //switch back to original window
            driver.SwitchTo().Window(mainWindow);
