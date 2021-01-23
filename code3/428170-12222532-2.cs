    private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            try
            {
                // Assign startup and quit events
                Application.Startup += new Outlook.ApplicationEvents_11_StartupEventHandler(ApplicationObject_Startup);
                ((Outlook.ApplicationEvents_11_Event)Application).Quit += new Outlook.ApplicationEvents_11_QuitEventHandler(ApplicationObject_Quit);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "EXCEPTION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            try
            {
                // Remove the startup and quit events
                Application.Startup -= new Outlook.ApplicationEvents_11_StartupEventHandler(ApplicationObject_Startup);
                ((Outlook.ApplicationEvents_11_Event)Application).Quit -= new Outlook.ApplicationEvents_11_QuitEventHandler(ApplicationObject_Quit);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "EXCEPTION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void ApplicationObject_Startup()
        {
            try
            {
                // Minimize to taskbar
                Application.ActiveExplorer().WindowState = Outlook.OlWindowState.olMinimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "EXCEPTION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void ApplicationObject_Quit()
        {
            try
            {
                // Restart outlook minimized
                ProcessStartInfo psiOutlook = new ProcessStartInfo("OUTLOOK.EXE", "/recycle");
                psiOutlook.WindowStyle = ProcessWindowStyle.Minimized;
                Process.Start(psiOutlook);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "EXCEPTION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
