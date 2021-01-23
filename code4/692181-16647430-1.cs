    private void btnPrint_Click(object sender, EventArgs e)
    {         
        PaperSize pp = new PaperSize("MyReport", 718, 359);
        printForm1.PrinterSettings.DefaultPageSettings.PaperSize = pp;
        printForm1.PrinterSettings.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
        // Show the labels...
        lblAge.Visible = true;
        lblAdd.Visible = true;
        lblName.Visible = true;
        lblEmail.Visible = true;
        // ...Print them visible...
        printForm1.Print(this, PrintForm.PrintOption.CompatibleModeClientAreaOnly);
        // ...Then hide again
        lblAge.Visible = false;
        lblAdd.Visible = false;
        lblName.Visible = false;
        lblEmail.Visible = false;
    }
