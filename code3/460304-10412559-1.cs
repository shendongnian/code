    private void ExportGridView()
    {
        System.IO.StringWriter sw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
        // Render grid view control.
        gvFiles.RenderControl(htw);
        // Write the rendered content to a file.
        string renderedGridView = sw.ToString();
        System.IO.File.WriteAllText(@"C:\Path\On\Server\ExportedFile.xlsx", renderedGridView);
    }
