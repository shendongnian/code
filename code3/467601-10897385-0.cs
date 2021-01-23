    int pageRows=0;    
    while (pageRows<datatable.Rows.Count+8)
          {
             content.BeginText();
             table.WriteSelectedRows(pageRows, pageRows+9, 20, 550, cb);
             pageRows = pageRows + 9;
             content.EndText();
             document.NewPage();
           }
