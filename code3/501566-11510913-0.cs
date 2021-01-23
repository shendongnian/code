    public void Detail_BeforePrint(object sender, System.EventArgs eArgs)
    {
        this.CurrentPage.BackColor = System.Drawing.Color.Purple;
        this.CurrentPage.ForeColor = System.Drawing.Color.YellowGreen;
        this.CurrentPage.PenStyle = DataDynamics.ActiveReports.Document.PenStyles.Dot;
        this.CurrentPage.PenWidth = 4;
        this.CurrentPage.DrawLine(Detail.CurrentLocation.X, Detail.CurrentLocation.Y, this.PrintWidth, Detail.Height);
    }
