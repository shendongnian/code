    //Process all Paragraphs in the documents
    while (doc.ActiveWindow.Selection.Bookmarks.Exists(@"\EndOfDoc") == false)
    {
      doc.ActiveWindow.Selection.MoveDown(ref wdLine, ref wdCountOne, ref wdMove);
      doc.ActiveWindow.Selection.HomeKey(ref wdLine, ref wdMove);
    
      //Skiping table content
      if (doc.ActiveWindow.Selection.get_Information(WdInformation.wdEndOfRangeColumnNumber).ToString() != "-1")
      {
        while (doc.ActiveWindow.Selection.get_Information(WdInformation.wdEndOfRangeColumnNumber).ToString() != "-1")
        {
          if (doc.ActiveWindow.Selection.Bookmarks.Exists(@"\EndOfDoc"))
            break;
    
          doc.ActiveWindow.Selection.MoveDown(ref wdLine, ref wdCountOne, ref wdMove);
          doc.ActiveWindow.Selection.HomeKey(ref wdLine, ref wdMove);
        }
        doc.ActiveWindow.Selection.HomeKey(ref wdLine, ref wdMove);
      }
    
      doc.ActiveWindow.Selection.EndKey(ref wdLine, ref wdExtend);
      currLine = doc.ActiveWindow.Selection.Text;
    }
    
    //Processing all tables in the documents
    for (int iCounter = 1; iCounter <= doc.Tables.Count; iCounter++)
    {
      foreach (Row aRow in doc.Tables[iCounter].Rows)
      {
        foreach (Cell aCell in aRow.Cells)
        {
          currLine = aCell.Range.Text;
          //Process Line
        }
      }
    }
