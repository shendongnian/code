        private void NodeConfigurationWizardCustomizeCommandButtons(object sender, CustomizeCommandButtonsEventArgs e)
        {
                _nextButton = e.NextButton;}
            private void GetRowsButtonClick(object sender, EventArgs e)
        {
                var rowList = ServiceClient.GetAvailableRows();
                var rowsReturned = rowList.Count > 0;
                _nextButton.Button.Enabled = rowsReturned ;}
