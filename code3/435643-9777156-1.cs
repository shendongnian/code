    string GetCellText( TableCell cell ) {
      var p = cell.Elements<Paragraph>().First();
      var r = p.Elements<Run>().First();
      var t = r.Elements<Text>().First();
      return t.Text;
    }
      
