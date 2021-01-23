        public event AddEventHandlerToSPDialogEvent ResultOk;
        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int dialogResult = 0;
                if (this.ResultOk != null)
                {// Here dialogResult is 0. that means we have clicked on cancel button
                    ResultOk(this, new SPDialogEventHandler(dialogResult,"Action Cancelled"));
                }
            }
            catch (Exception ex) { }
        }
