    System.Text.StringBuilder store = new System.Text.StringBuilder();
    string line;
         while ((line = htmlReader.ReadLine()) != null)
         {
           store.Append(line + Environment.NewLine);
         }
                    
    string html = store.ToString();
    FileStream stream = new FileStream(newFileName, FileMode.Create, FileAccess.Write);
    Document document = new Document(PageSize.LETTER, 15, 15, 35, 25);
    PdfWriter writer = PdfWriter.GetInstance(document, stream);
    document.Open();
    System.Collections.Generic.List<IElement> htmlarraylist = new List<IElement>(HTMLWorker.ParseToList(new StringReader(html), new StyleSheet()));
         foreach (IElement element in htmlarraylist)
         {
            document.Add(element);
         }
    document.Close();
