    // The Reporting.Web part is my namespace. Everything here is case sensitive!
    string template = "Reporting.Web.PerfRevH1.docx";
    Assembly loader = Assembly.GetExecutingAssembly();
    var rawstream = loader.GetManifestResourceStream(template);
    byte[] byteArray = rawstream.ReadToEnd();
