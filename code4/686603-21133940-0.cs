    /// <summary>
        /// Loading the QV document and a retry when we have missed contact with the qv document.
        /// </summary>
        private void LoadQvIfNecessary(bool forceDocumentReload =false)
        {
            Parent.Text = DateTime.Now.ToLongTimeString();
            if (forceDocumentReload)
                axQlikMainApp.DocName = null;
            if (axQlikMainApp.ActiveDocument == null)
                axQlikMainApp.DocName = Loader.Instance.Settings.QlikViewPlanningDocumentPath;
                Thread.Sleep(100);
            if (axQlikMainApp.ActiveDocument == null)
            {
                DialogResult result = Logger.ShowMessage("Du har tappat kontakten med databasen.\nVill du återuppta kontakten med databasen?\nOm du väljer ”Avbryt” stängs programmet ned.","Tappat kontakt",Logger.MessageLevel.CriticalError,MessageBoxButtons.RetryCancel);
                if (result == DialogResult.Cancel)
                    Environment.Exit(0);
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(300);
                    Application.DoEvents();
                }
               
                LoadQvIfNecessary();
            }
        }
