    foreach (NetOffice.WordApi.InlineShape s in docWord.InlineShapes)
    {
          #region Set Shapes
          if (s.Type==NetOffice.WordApi.Enums.WdInlineShapeType.wdInlineShapePicture &&  s.AlternativeText.Contains("|"))
          {
                 Clipboard.SetImage(s.Select());
          }
    }
