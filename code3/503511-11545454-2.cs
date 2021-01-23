    protected override void Render(HtmlTextWriter writer)
    {
     sw = new StringWriter();
     htmltw = new HtmlTextWriter(sw); 
     base.Render(htmltw);
     StringBuilder html = sw.GetStringBuilder();
     string outputFileLocation = currDir + "\\" + "outputFile.html";
     FileStream fs = File.Open(outputFileLocation, FileMode.Create, FileAccess.Write);
     using (StreamWriter sw = new StreamWriter(fs))
     {
      sw.WriteLine(html);
     }
     writer.Write(sOut);
    }
