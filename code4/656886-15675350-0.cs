     Microsoft.Office.Interop.Word.Application w = new icrosoft.Office.Interop.Word.Application();
     Microsoft.Office.Interop.Word.Document doc;
     doc = w.ActiveDocument;
     doc.PageSetup.DifferentFirstPageHeaderFooter = -1;
     // Setting Different First page Header & Footer
     doc.Sections[1].Headers[WdHeaderFooterIndex.wdHeaderFooterFirstPage].Range.Text = "First Page Header";
     doc.Sections[1].Footers[WdHeaderFooterIndex.wdHeaderFooterFirstPage].Range.Text = "First Page Footer";
    
     // Setting Other page Header & Footer
     doc.Sections[1].Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Text = "Other Page Header";
     doc.Sections[1].Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Text = "Other Page Footer";
