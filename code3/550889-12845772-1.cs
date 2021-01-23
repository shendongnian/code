        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                //Do not display SelectedFilesCount progress indicator.
                RadProgressArea1.ProgressIndicators &= ~ProgressIndicators.SelectedFilesCount;
            }
            RadProgressArea1.Localization.Uploaded = "Total Progress";
            RadProgressArea1.Localization.UploadedFiles = "Progress";
            RadProgressArea1.Localization.CurrentFileName = "Custom progress in action: ";
        }
        protected void buttonSubmit_Click(object sender, System.EventArgs e)
        {
            UpdateProgressContext();
        }
        private void UpdateProgressContext()
        {
            const int total = 100;
            RadProgressContext progress = RadProgressContext.Current;
            progress.Speed = "N/A";
            for (int i = 0; i < total; i++)
            {
                progress.PrimaryTotal = 1;
                progress.PrimaryValue = 1;
                progress.PrimaryPercent = 100;
                progress.SecondaryTotal = total;
                progress.SecondaryValue = i;
                progress.SecondaryPercent = i;
                progress.CurrentOperationText = "Step " + i.ToString();
                if (!Response.IsClientConnected)
                {
                    //Cancel button was clicked or the browser was closed, so stop processing
                    break;
                }
                progress.TimeEstimated = (total - i) * 100;
                //Stall the current thread for 0.1 seconds
                System.Threading.Thread.Sleep(100);
            }
        }    
