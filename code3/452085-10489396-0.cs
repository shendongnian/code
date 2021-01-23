    private void frmUsr_ValueUpdated(object sender, ValueUpdatedEventArgs e) //---added 3-22-12
        {
            // Update the printer name on Form1 with the new value from formUserSettings
            string prnStr = e.NewValue;
            string[] parts = prnStr.Split('^'); //the printer name, driver and port were passed by e.NewValue, being separated by a "^"
            //---added 5-7-12
            EViewMethods.defaultPrn[0] = parts[0]; //printer name
            EViewMethods.defaultPrn[1] = parts[1]; //printer driver
            EViewMethods.defaultPrn[2] = parts[2]; //printer port
            toolStripStatusLabel3.Text = parts[0];
            //---added 5-7-12
            if (frmVD != null && !frmVD.IsDisposed) //want to send the new printer name now if formViewDwg is already open. If it is not open, then when it is called to open, the formViewDwg constructor will pass the new printer to it.
            {
                frmVD.ProcessPrinterName(parts[0]); //ProcessPrinterName is a public method inside formViewDwg.  Can call here because formViewDwg is already open!
            }
        }
