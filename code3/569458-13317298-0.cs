    files.Add(PDFhelper.fillTemplate(template, mappings));
    foreach (Update u in myObject.Updates)
    {
        mappings = this.GenerateFieldMappings(u);
        using(Stream output = new MemoryStream())
        {
            template.CopyTo(output);
            files.Add(PDFhelper.fillTemplate(output, mappings)); //First time stream is good
        }
    }
    return PDFhelper.MergeFiles(files);
