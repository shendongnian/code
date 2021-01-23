    private void btnOpenAsJRN_Click(object sender, EventArgs e) {
        string fileToOpen = this.localDownloadPath + "\\" + this.filenameToDownload;
        //Create a StreamReader object
        reader = new StreamReader(fileToOpen);
        //Create a Verdana font with size 10
        lucida10Font = new Font("Lucida Console", 10);
        //Create a PrintDocument object
        PrintDocument pd = new PrintDocument();
    
        PaperSize paperSize = new PaperSize("Custom", 400, 1097);
        paperSize.RawKind = (int)PaperKind.Custom;
        pd.DefaultPageSettings.PaperSize = paperSize;
        pd.DefaultPageSettings.Margins = new Margins(20, 20, 30, 30);
    
        pd.PrinterSettings.PrinterName = ConfigurationManager.AppSettings["journalNotePrinter"];
        pd.DocumentName = this.filenameToDownload;
        //Add PrintPage event handler
        pd.PrintPage += new PrintPageEventHandler(this.PrintTextFileHandler);
    
        //Call Print Method
        try {
            pd.Print();
        }
        finally {
            //Close the reader
            if (reader != null) {
                reader.Close();
            }
            this.savedJnt = fileToOpen.Replace("txt", "jnt");
            System.Threading.Thread.Sleep(1000);
            if (File.Exists(this.savedJnt)) {
                lblJntSaved.Visible = true;
                lblJntSaved.ForeColor = Color.Green;
                lblJntSaved.Text = "File successfully located.";
                // If the file can be found, show all of the buttons for completing 
                // the final steps.
                lblFinalStep.Visible = true;
                btnMoveToSmoketown.Visible = true;
                btnEmail.Visible = true;
                txbEmailAddress.Visible = true;
            }
            else {
                lblJntSaved.Visible = true;
                lblJntSaved.ForeColor = Color.Red;
                lblJntSaved.Text = "File could not be located. Please check your .jnt location.";
            }
        }
    }
    
    private void PrintTextFileHandler(object sender, PrintPageEventArgs ppeArgs) {
        //Get the Graphics object
        Graphics g = ppeArgs.Graphics;
        float linesPerPage = 0;
        float yPos = 0;
        int count = 0;
        //Read margins from PrintPageEventArgs
        float leftMargin = ppeArgs.MarginBounds.Left;
        float topMargin = ppeArgs.MarginBounds.Top;
        string line = null;
        //Calculate the lines per page on the basis of the height of the page and the height of the font
        linesPerPage = ppeArgs.MarginBounds.Height /
        lucida10Font.GetHeight(g);
        //Now read lines one by one, using StreamReader
        while (count < linesPerPage &&
        ((line = reader.ReadLine()) != null)) {
            //Calculate the starting position
            yPos = topMargin + (count *
            lucida10Font.GetHeight(g));
            //Draw text
            g.DrawString(line, lucida10Font, Brushes.Black,
            leftMargin, yPos, new StringFormat());
            //Move to next line
            count++;
        }
        //If PrintPageEventArgs has more pages to print
        if (line != null) {
            ppeArgs.HasMorePages = true;
        }
        else {
            ppeArgs.HasMorePages = false;
        }
    }
