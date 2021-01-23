    using System.Globalization;
    internal void Application_BeginRequest(object sender, EventArgs e)
    {
        CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("tk-TR");
    }
