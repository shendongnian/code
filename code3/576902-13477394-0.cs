    class ReportShaft : Label
    {
      public virtual IList<Microsoft.Reporting.WinForms.ReportParameter> NewReportSetup(string abs)
        {
       base.NewReportSetup("part", "batch", "locn", "wheel","gear", "length", "fits", "newbar",  "newbarnum", abs)
    }
    }
