    foreach (NetOffice.WordApi.InlineShape s in docWord.InlineShapes)
    {
                    if (s.Type==NetOffice.WordApi.Enums.WdInlineShapeType.wdInlineShapePicture &&  s.AlternativeText.Contains("any pattern you are looking for"))
                    {
                            <Do your manipulation with image change it>
                            s.Range.InsertFile(<insert your new picture for example>);
                    }
     }
                
