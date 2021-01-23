        foreach (Word.Section section in newDocument.Sections)
            {
                string picturePath = @"D:\Desktop\test.png";
                section.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.InlineShapes.AddPicture(picturePath);
                section.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            }
