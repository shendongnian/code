    //Upload and convert a File when a Button is pushed
    protected void Button1_Click(object sender, EventArgs e)
    {
        if(FileUpload1.HasFile)
        {
            string iEXT = Path.GetExtension(FileUpload1.FileName);
            byte[] iMEM = FileUpload1.FileBytes;
            byte[] oMEM;
            Printer oPrin = new Printer();
            PrintJob oPJob = oPrin.PrintJob;
            try
            {
                oMEM = oPJob.PrintOut3(iMEM, iEXT);
            }
            catch (PrinterException ex)
            {
                //Perform your desired Error Handling
            }
            finally
            {
                oPrin.Dispose();
            }
            // Save oMEM as Desired, or use it how you see fit.
        }
    }
