    private void ExportGridView()
    {
        var path = @"C:\test\ExportedFile.xls";
        System.IO.StringWriter sw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
        // Render grid view control.
        gvFiles.RenderControl(htw);
        // Write the rendered content to a file.
        string renderedGridView = sw.ToString();
        File.WriteAllText(path, renderedGridView);
        UpdateFormat(path);
    }
