    SsinpatDataContext dc = new SsinpatDataContext(){Log=Console.Out};
    Document doc = new Document();
    doc.Text = "bla bla bla";
    DocumentRows dr = new DocumentRows();
    dr.Text = "bla bla bla";
    dr.Doc = doc;
    dc.Documents.InsertOnSubmit(doc);
    dc.SubmitChanges(); 
