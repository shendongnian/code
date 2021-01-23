    '   #region ClearOutputWindow
        /// <summary>
        /// Clear the Output window-pane of Visual Studio.
        /// Note: Causes a 1-second delay.
        /// </summary>
        public static void ClearOutputWindow()
        {
            if (!Debugger.IsAttached)
            {
                return;
            }
            //Application.DoEvents();  // This is for Windows.Forms.
            // This delay to get it to work. Unsure why. See http://stackoverflow.com/questions/2391473/can-the-visual-studio-debug-output-window-be-programatically-cleared
            Thread.Sleep(1000);
            // In VS2008 use EnvDTE80.DTE2
            EnvDTE.DTE ide = (EnvDTE.DTE)Marshal.GetActiveObject("VisualStudio.DTE.10.0");
            if (ide != null)
            {
                ide.ExecuteCommand("Edit.ClearOutputWindow", "");
                Marshal.ReleaseComObject(ide);
            }
        }
        #endregion
'
