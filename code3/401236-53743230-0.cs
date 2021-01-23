            Actions action = new Actions(driver);
            action.SendKeys(pObjElement, Keys.Space).Build().Perform();
            
            Thread.Sleep(TimeSpan.FromSeconds(2));
            
            var dialogHWnd = FindWindow(null, "Elegir archivos para cargar"); // Here goes the title of the dialog window
            var setFocus = SetForegroundWindow(dialogHWnd);
            if (setFocus)
            {
                
                Thread.Sleep(TimeSpan.FromSeconds(2));
                System.Windows.Forms.SendKeys.SendWait(pFile);
                System.Windows.Forms.SendKeys.SendWait("{DOWN}");
                System.Windows.Forms.SendKeys.SendWait("{TAB}");
                System.Windows.Forms.SendKeys.SendWait("{TAB}");
                System.Windows.Forms.SendKeys.SendWait("{ENTER}");
            }
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }
