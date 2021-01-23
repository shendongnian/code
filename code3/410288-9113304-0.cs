    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        RadGridName.GridExporting += (s, a) => 
        {
            string myHtmlCode = "<span>My HTML code goes here</span>";
            a.ExportOutput = a.ExportOutput.Replace("<body>", "<body>" + myHtmlCode);
        };
    }
